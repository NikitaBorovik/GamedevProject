using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace App.World.Entity.Player.Weapons
{
    public class TimeToLive : MonoBehaviour
    {
        [SerializeField]
        private float timeToLive;
        /*    [SerializeField]
            private float timeToLiveLeft;*/
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, timeToLive);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}