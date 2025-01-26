using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
   
    [Header("Sounds")]
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioSource audioSourceExplosion;
    [SerializeField] private AudioSource audioSourceRound;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderExplosion;
    [SerializeField] private Slider sliderRound;

    private void Update()
    {
       audioSourceMusic.volume = sliderMusic.value;
       audioSourceExplosion.volume = sliderExplosion.value;
       audioSourceRound.volume = sliderRound.value;
    }
}

    
