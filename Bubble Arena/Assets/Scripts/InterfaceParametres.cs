using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceParametres : MonoBehaviour
{
    public Slider sliderVolume;

    public void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        sliderVolume.value = savedVolume;
        AudioListener.volume = savedVolume;

        sliderVolume.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void QuitSettings()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetSettings()
    {
        if (sliderVolume != null)
        {
            Debug.Log("reset du slider à la valeur max");
            sliderVolume.value = sliderVolume.maxValue;
        }
        else
        {
            Debug.LogError("Le slide n'est pas assigné dans l'Inspector");
        }
        
    }
}
