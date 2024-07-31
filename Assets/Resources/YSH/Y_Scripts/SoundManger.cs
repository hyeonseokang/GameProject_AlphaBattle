using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AudioEnum
{
    EAT,
    START,
    HITAA,
    WIN,
    CATCH,
    LOSE,
    DEATH,
    CHULKUK,
    CLICK,
    WALK,
    SWORD
}
public class SoundManger : MonoBehaviour
{
    public static SoundManger instance;
    public AudioSource audio;
    public AudioClip[] _audio;

    private void Start()
    {
        if (instance == null)
            instance = this;
        audio = GetComponent<AudioSource>();
    }

    public void Play(AudioEnum _enum)
    {
        audio.PlayOneShot(_audio[(int)_enum]);
    }

    //public void SFXVolume()
    //{
    //    audio.volume = SFXSlider.value;
    //}
}