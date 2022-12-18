using UnityEngine;
using App.World.Entity.Player.Events;

public class HPBar : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private Transform hpBarTransform;
    [SerializeField] private HPUpdateEvent HPUpdateEvent;
    [Range(0f, 1f)]
    [SerializeField] private float currentPercentage;

    public float CurrentPercentage
    {
        get => currentPercentage;
        set
        {
            if (value < -Mathf.Epsilon || value > 1 + Mathf.Epsilon)
                throw new System.InvalidOperationException("Percentage ranges between 0 and 1.");
            currentPercentage = value;
            SetGUIPercentage(value);
        }
    }

    private void OnEnable()
    {
        HPUpdateEvent.OnHPUpdate += OnHPUpdate;
    }

    private void OnDisable()
    {
        HPUpdateEvent.OnHPUpdate -= OnHPUpdate;
    }

    private void SetGUIPercentage(float percentage)
    {
        var prev = hpBarTransform.localScale;
        hpBarTransform.localScale = new (percentage, prev.y, prev.z);
    }

    private void OnHPUpdate(HPUpdateEvent ev, HPUpdateEventArgs args)
        => CurrentPercentage = args.newHP >= 0f ? args.newHP / args.maxHP : 0f;
}
