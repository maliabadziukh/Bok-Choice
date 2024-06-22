using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    public IEnumerator PlaySound(AudioClip clip)
    {
        audioSrc.clip = clip;
        audioSrc.Play();
        print("playing sound");
        yield return null;
    }
}
