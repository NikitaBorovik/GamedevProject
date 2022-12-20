using UnityEngine;

namespace App.Utilities
{
    public class OnSceneSwitchedCallBack : MonoBehaviour
    {
        [SerializeField] private float minimalLoadingTime;
        private float currTime;

        private void Awake()
        {
            currTime = 0f;
        }

        private void FixedUpdate()
        {
            currTime += Time.fixedDeltaTime;

            if(currTime > minimalLoadingTime)
            {
                SceneSwitcher.SwitchToNextLoadedScene?.Invoke();
            }
        }
    }
}