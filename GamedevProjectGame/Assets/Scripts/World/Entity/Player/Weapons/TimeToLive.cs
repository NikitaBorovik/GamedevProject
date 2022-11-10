using App.Systems.EnemySpawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace App.World.Entity.Player.Weapons
{
    public class TimeToLive : MonoBehaviour
    {
        [SerializeField]
        private float timeToLive;
        private ObjectPool objectPool;
        /*    [SerializeField]
            private float timeToLiveLeft;*/
        // Start is called before the first frame update
        public void Init()
        {
            objectPool = FindObjectOfType<ObjectPool>();
            IObjectPoolItem objectPoolItem = GetComponent<IObjectPoolItem>();
            if (objectPoolItem == null)
                Destroy(gameObject, timeToLive);
            else
            {
                StartCoroutine(destroyObjectPoolItem(timeToLive, objectPoolItem));
                //Debug.Log("Returned to pool");
            }
                
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator destroyObjectPoolItem(float delay,IObjectPoolItem item)
        {
            yield return new WaitForSeconds(delay);
            objectPool.ReturnToPool(item);
        }
    }
}