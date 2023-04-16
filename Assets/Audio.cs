
using System;
using UnityEngine;

// Singleton
public class Audio : MonoBehaviour
{
    public static AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void Play(AudioClip clip,float volume = 1f)
    {
        source.PlayOneShot(clip,volume);
    }
}
