using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UIElements;

public class VolumSetting : MonoBehaviour
{
    [SerializeField] private AudioSource myMixer;
    [SerializeField] private UnityEngine.UI.Slider musicSlider;

    void Update()
    {
        myMixer.volume = musicSlider.value / 100;
    }

}