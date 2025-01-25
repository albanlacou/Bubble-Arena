using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] roundSound;

    [SerializeField]
    private AudioSource explosion;

    [SerializeField]
    private AudioSource roundSource;

    [SerializeField]
    private AudioSource music;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playExplosion()
    {
        explosion.Play();

    }

    public void playRound(int round)
    {
        roundSource.clip = roundSound[round - 1];
        musicVolumeDown();
        roundSource.Play();
        Invoke(nameof(musicVolumeUp),2f);
    }

    public void musicVolumeDown()
    {
        music.volume = 0.4f;
    }

    public void musicVolumeUp()
    {
        
        music.volume = 1f;
    }
}

