using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicVolumeChanger : MonoBehaviour
{
    public void VolumeUp()
    {
        if (AudioListener.volume < 1f)
        {
            AudioListener.volume += 0.1f;
        }
        if (AudioListener.volume > 1f)
            AudioListener.volume = 1f;
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
    }
    public void VolumeDown()
    {
        if (AudioListener.volume > 0f)
        {
            AudioListener.volume -= 0.1f;
        }
        if (AudioListener.volume < 0f)
            AudioListener.volume = 0f;
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
    }
}
