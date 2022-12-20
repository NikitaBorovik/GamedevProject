using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{


    private void Awake()
    {
        
    }

    public void SwitchToScene(string sceneName) 
    {
        if (!DoesSceneExist(sceneName))
            throw new ArgumentException ($"The scene {sceneName} does not exist in the build settings" +
                $" or is not enabled. Add the one to build settings or enable.");

        if (IsRunning(sceneName))
            throw new InvalidOperationException($"Cannot switch to scene {sceneName} that is currently running.");
       
        SceneManager.LoadScene(sceneName);
    } 

    public bool DoesSceneExist(string sceneName)
        => EditorBuildSettings.scenes.Any
        (
            scene => scene.enabled && scene.path.Contains("/" + sceneName + ".unity")
        );

    public bool IsRunning(string sceneName)
       => SceneManager.GetActiveScene().name == sceneName;
}
