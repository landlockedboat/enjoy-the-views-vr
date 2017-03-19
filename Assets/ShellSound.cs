using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSound : MonoBehaviour {
    AudioSource audioSource;
    bool finished = false;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (finished ||collision.gameObject.tag != "Terrain")
        {
            return;
        }
        audioSource.Play();
        finished = true;
    }
}
