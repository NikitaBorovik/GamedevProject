using TMPro;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    [SerializeField] private float oneDotAppearanceTime;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string defaultText;
    private float passedTime;
    private int currentNumOfDots;
    private const int maxNumOfDots = 3; 

    private void Awake()
    {
        passedTime = 0f;
        text.text = defaultText;
    }

    private void Update()
    {
        if (passedTime > oneDotAppearanceTime)
        {
            Debug.Log("passedTime > oneDotAppearanceTime");
            passedTime = 0f;
            AddOneDot();
        }
        else
        {

            Debug.Log("passedTime <= oneDotAppearanceTime");
            passedTime += Time.deltaTime;
        }
    }

    private void AddOneDot()
    {
        Debug.Log("Add one dot");
        if(currentNumOfDots == maxNumOfDots)
        {
            text.text = defaultText;
            currentNumOfDots = 0;
        }
        else
        {
            text.text += '.';
            ++currentNumOfDots;
        }
    }
}
