using UnityEngine;
using TMPro;
using App.World.Entity.Player.Events;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathScreenCanvas;
    [SerializeField] private TextMeshProUGUI scoreTMP;
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

    private void OnEnable()
    {
        dieEvent.OnDied += ShowDeathScreenEvent;
    }

    private void OnDisable()
    {
        dieEvent.OnDied -= ShowDeathScreenEvent;
    }

    public void ShowDeathScreenWithScore(int score)
    {
        Score = score;
        ShowDeathScreen();
    }

    public void ShowDeathScreen()
    {
        deathScreenCanvas.SetActive(true);
    }

    public void HideDeathScreen()
    {
        deathScreenCanvas.SetActive(false);
    }

    private void ShowDeathScreenEvent(DieEvent ev) => ShowDeathScreen();
}
