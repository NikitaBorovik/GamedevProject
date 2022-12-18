using UnityEngine;
using App.World.UI.Events;
using TMPro;

public class IconCounter : MonoBehaviour
{
    [SerializeField] private CountUpdatedEvent countUpdatedEvent;
    [SerializeField] private TextMeshProUGUI text;
    private int count;

    public int Count
    {
        get => count;
        set
        {
            if(value < 0)
                throw new System.ArgumentOutOfRangeException("Count cannot be less then 0");
            count = value;
            text.text = "x" + value.ToString();
        }
    }

    private void OnEnable()
    {
        countUpdatedEvent.OnCountUpdated += UpdateCountAndText;
    }

    private void OnDisable()
    {
        countUpdatedEvent.OnCountUpdated -= UpdateCountAndText;
    }

    private void UpdateCountAndText(CountUpdatedEvent ev, CountUpdatedEventArgs args) => Count = args.newCount;
}
