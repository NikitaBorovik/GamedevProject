using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    [SerializeField]
    private float timeToLive;
/*    [SerializeField]
    private float timeToLiveLeft;*/
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timeToLive);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
