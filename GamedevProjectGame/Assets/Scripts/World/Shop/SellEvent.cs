using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellEvent : MonoBehaviour
{
    public event Action<SellEvent> OnSell;

    public void CallSellEvent()
    {
        OnSell?.Invoke(this);
    }
}
