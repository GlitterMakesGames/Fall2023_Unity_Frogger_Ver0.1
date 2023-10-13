using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundFX;
    public AudioClip[] bgMusic;
    AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
}