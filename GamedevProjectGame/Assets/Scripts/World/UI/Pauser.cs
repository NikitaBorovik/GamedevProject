using App.World.UI.Events;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] private Animator planksWithButtonsAnimator;
    [SerializeField] private DeathScreenAppearedEvent onDeathScreenAppeared;
    private Animator fadeAnimator;
    private bool isPaused;
    private float prepauseTimeScale;

    public bool IsPaused => isPaused;

    private void Awake()
    {
        fadeAnimator = fade.GetComponent<Animator>();
        isPaused = false;
        prepauseTimeScale = Time.timeScale;
    }

    private void Start()
    {
        fade.SetActive(false);
    }

    private void OnEnable()
    {
        onDeathScreenAppeared.OnDeathScreenAppeared += StopGameEvent;
    }

    private void OnDisable()
    {
        onDeathScreenAppeared.OnDeathScreenAppeared -= StopGameEvent;
    }

    public void Pause()
    {
        if (isPaused)
            throw new System.InvalidOperationException("Cannot pause an already paused game.");
        fade.SetActive(true);
        planksWithButtonsAnimator.Play("AppearPlanksWithButtons");
        fadeAnimator.Play("Fade");
        StopGame();
    }

    public void Unpause()
    {
        if (!isPaused)
            throw new System.InvalidOperationException("Cannot unpause a not paused game.");
        planksWithButtonsAnimator.Play("DisappearPlanksWithButtons");
        fadeAnimator.Play("Unfade");
        RenewGame();
    }

    private void StopGame()
    {
        isPaused = true;
        prepauseTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    private void RenewGame()
    {
        isPaused = false;
        Time.timeScale = prepauseTimeScale;
    }

    private void StopGameEvent(DeathScreenAppearedEvent ev) => StopGame();

}
