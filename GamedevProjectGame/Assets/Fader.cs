using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image fadingImage;
    [Range(0, 1)]
    [SerializeField] private float initialAlpha;

    private float Alpha
    {
        get => fadingImage.color.a;
        set
        {
            var prevColor = fadingImage.color;
            fadingImage.color = new Color(prevColor.r, prevColor.g, prevColor.b, value);
        }
    }

    private void Awake()
    {
        Alpha = initialAlpha;
    }

    public void FadeToOneSeconds(float seconds) => FadeToSeconds(1f, seconds);

    public void FadeToZeroSeconds(float seconds) => FadeToSeconds(0f, seconds);

    public void FadeToSeconds(float newAlpha, float seconds) 
        => StartCoroutine(FadeToSecondsCoroutine(newAlpha, seconds));

    public IEnumerator FadeToSecondsCoroutine(float newAlpha, float seconds)
    {
        var speed = (newAlpha - Alpha) / seconds;
        while(!Mathf.Approximately(newAlpha, Alpha))
        {
            Alpha = Alpha + speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
