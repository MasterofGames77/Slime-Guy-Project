using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMusic : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject ObjectMusic;

    private float MusicVolume = 0f;
    private AudioSource AudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        //AudioSource.Play();
        ObjectMusic = GameObject.FindWithTag("Game Music");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        // Set Volume
        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    }

    // Update is called once per frame
    private void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void VolumeUpdater(float volume)
    {
        MusicVolume = volume;
    }

    /*public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 1;
        volumeSlider.value = 1;
    }*/
}