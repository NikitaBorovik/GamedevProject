using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTheBase : MonoBehaviour
{
    [SerializeField]
    private GameObject exitChecker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enter();
    }
    private void Enter()
    {
        exitChecker.SetActive(true);
    }
}
