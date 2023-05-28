using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioModel
{
    public string audioName;

    public AudioClip audioClip;

    public bool mute;

    public bool loop;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource audioSource;
}
