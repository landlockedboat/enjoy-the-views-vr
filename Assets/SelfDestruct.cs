using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    [SerializeField]
    float timeTillSelfDestruction = 1f;

    void Start()
    {
        Invoke("KillYourself", timeTillSelfDestruction);
    }

    void KillYourself()
    {
        Destroy(gameObject);
    }
}
