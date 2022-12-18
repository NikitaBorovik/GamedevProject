using System.Collections;
using UnityEngine;
using TMPro;
using App.World.Entity.Player.Events;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathScreenCanvas;
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private Fader fader;
    [SerializeField] private DieEvent dieEvent;
    private int score;

    public int Score
    {
        get => score;
        set
        {
            if (value < 0)
                throw new System.InvalidOperationException("Score cannot be negative.");
            score = value;
            scoreTMP.text = "Score: " + score.ToString();
        }
    }

    private void Awake()
    {
        score = 0;
    }

    private void Start()
    {
        HideDeathScreen();
    }

    private void OnEnable() => AddAllOnEvent();
    
    private void OnDisable() => RemoveAllOnEvent();

    public void ShowDeathScreenWithScore(int score)
    {
        Score = score;
        ShowDeathScreen();
    }

    public void ShowDeathScreen()
    {
        StartCoroutine(ShowDeathScreenCoroutine(1f));
    }

    public IEnumerator ShowDeathScreenCoroutine(float seconds)
    {
        RemoveAllOnEvent();
        float halfTime = seconds * 0.5f;
        yield return fader.FadeToSecondsCoroutine(1f, halfTime);
        deathScreenCanvas.SetActive(true);
        yield return fader.FadeToSecondsCoroutine(0f, halfTime);
    }

    public void HideDeathScreen()
    {
        deathScreenCanvas.SetActive(false);
    }

    private void ShowDeathScreenEvent(DieEvent ev) => ShowDeathScreen();

    private void AddAllOnEvent()
    {
        dieEvent.OnDied += ShowDeathScreenEvent;
    }

    private void RemoveAllOnEvent()
    {
        dieEvent.OnDied -= ShowDeathScreenEvent;
    }
}
