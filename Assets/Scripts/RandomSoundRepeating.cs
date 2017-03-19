using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundRepeating : MonoBehaviour {
    [SerializeField]
    AudioClip[] audioClips;
    AudioSource audioSource;
    [SerializeField]
    float timeToRepeat = 2f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Shout", timeToRepeat, timeToRepeat);
    }

    void Shout()
    {
        AudioClip audioToPlay = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.clip = audioToPlay;
        audioSource.Play();
    }
}
