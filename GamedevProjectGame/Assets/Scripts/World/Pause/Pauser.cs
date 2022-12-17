using UnityEngine;

public class Pauser : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] private Animator planksWithButtonsAnimator;
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

    public void Pause()
    {
        if (isPaused)
            throw new System.InvalidOperationException("Cannot pause an already paused game.");
        fade.SetActive(true);
        planksWithButtonsAnimator.Play("AppearPlanksWithButtons");
        fadeAnimator.Play("Fade");
        isPaused = true;
        prepauseTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        if (!isPaused)
            throw new System.InvalidOperationException("Cannot unpause a not paused game.");
        planksWithButtonsAnimator.Play("DisappearPlanksWithButtons");
        fadeAnimator.Play("Unfade");
        isPaused = false;
        Time.timeScale = prepauseTimeScale;
        //fade.SetActive(false);
    }

}
