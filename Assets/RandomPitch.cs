using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class RandomPitch : MonoBehaviour {
    [SerializeField]
    float minPitch = .1f;
    [SerializeField]
    float maxPitch = 1.5f;

    void Awake()
    {
        GetComponent<AudioSource>().pitch = Random.Range(minPitch, maxPitch);
    }
}
