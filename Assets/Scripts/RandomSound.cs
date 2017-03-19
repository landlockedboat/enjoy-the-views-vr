using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {
    [SerializeField]
    AudioClip[] audioClips;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip audioToPlay = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.clip = audioToPlay;
        audioSource.Play();
    }
}
