using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds I { get; private set; }

    private void Awake()
    {
        I = this;
    }

    public void Play(AudioClip clip, float volume = 1)
    {
        var source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.Play();
        Destroy(source, clip.length);
    }
}
