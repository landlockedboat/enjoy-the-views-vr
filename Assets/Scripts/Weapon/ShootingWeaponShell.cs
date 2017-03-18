using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeaponShell : MonoBehaviour {

    [SerializeField]
    float initialForce = 10f;
    [SerializeField]
    float maxTorque = 5f;

    Rigidbody myRigidbody;

	void Start () {
        myRigidbody = GetComponent<Rigidbody>();

        myRigidbody.AddForce(transform.forward * -1 * initialForce, ForceMode.Impulse);
        float torque = maxTorque - (2 * maxTorque * Random.value);
        myRigidbody.AddTorque(transform.forward * torque);
    }
}
