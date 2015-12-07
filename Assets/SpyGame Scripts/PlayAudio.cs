using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour
{
    void OnEnable()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        audio.Play(44100);
    }
}