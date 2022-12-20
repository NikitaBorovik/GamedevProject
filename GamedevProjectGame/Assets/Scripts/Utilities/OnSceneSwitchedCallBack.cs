using UnityEngine;

public class OnSceneSwitchedCallBack : MonoBehaviour
{
    private void Start() => SceneSwitcher.SwitchToNextLoadedScene();
}
