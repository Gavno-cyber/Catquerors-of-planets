using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private AudioSource audioSrc;
    private float volume = 1f;
    public Slider fullVolume;
    public Slider musicVolume;
    public Slider effectVolume;

    void Start()
    {
        fullVolume.value = PlayerPrefs.GetFloat("Full", 1f);
        musicVolume.value = PlayerPrefs.GetFloat("Music", 1f);
        effectVolume.value = PlayerPrefs.GetFloat("Effects", 1f);
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = volume;
    }

    public void SetVolume(float vol)
    {
        volume = vol;
        PlayerPrefs.SetFloat("Full", vol);
    }

    public void SetMusic(float vol)
    {
        volume = vol;
        PlayerPrefs.SetFloat("Music", vol);
    }

    public void SetEffect(float vol)
    {
        volume = vol;
        PlayerPrefs.SetFloat("Effects", vol);
    }
}