using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunShell : MonoBehaviour {

    [SerializeField]
    float initialForce = 10f;
    [SerializeField]
    float maxTorque = 5f;

    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        myRigidbody.AddForce(transform.forward * initialForce, ForceMode.Impulse);
        float torque = maxTorque - (2 * maxTorque * Random.value);
        myRigidbody.AddTorque(transform.forward * torque);
    }
}
