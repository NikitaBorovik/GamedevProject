using UnityEngine;

public class Pauser : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] private GameObject planksWithButtons;
    private bool isPaused;
    private float prepauseTimeScale;

    public bool IsPaused => isPaused;

    private void Awake()
    {
        isPaused = true;
        prepauseTimeScale = Time.timeScale;
    }

    private void Start()
    {
        Unpause();
    }

    public void Pause()
    {
        if (isPaused)
            throw new System.InvalidOperationException("Cannot pause an already paused game.");
        fade.SetActive(true);
        planksWithButtons.SetActive(true);
        prepauseTimeScale = Time.timeScale;
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        if (!isPaused)
            throw new System.InvalidOperationException("Cannot unpause a not paused game.");
        fade.SetActive(false);
        planksWithButtons.SetActive(false);
        isPaused = false;
        Time.timeScale = prepauseTimeScale;
    }
}
