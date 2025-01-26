using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceParametres : MonoBehaviour
{
    public Slider sliderVolumeMusic;

    public void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        sliderVolumeMusic.value = savedVolume;
    }

    public void SetVolume(float volume)
    {
Debug.Log("oui" + volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void QuitSettings()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetSettings()
    {
        if (sliderVolumeMusic != null)
        {
            Debug.Log("reset du slider à la valeur max");
            sliderVolumeMusic.value = sliderVolumeMusic.maxValue;
        }
        else
        {
            Debug.LogError("Le slide n'est pas assigné dans l'Inspector");
        }
        
    }
}
