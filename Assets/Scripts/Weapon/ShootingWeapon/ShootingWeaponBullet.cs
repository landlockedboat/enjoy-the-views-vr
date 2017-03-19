using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeaponBullet : MonoBehaviour {
    [SerializeField]
    float damage = 5f;
    [SerializeField]
    float initalForce = 75;
    [SerializeField]
    GameObject bulletGeom;

    Rigidbody myRigidbody;
    bool hasCollided = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        myRigidbody.AddForce(transform.right * -1 * initalForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasCollided)
        {
            return;
        }
        if(collision == null)
        {
            Debug.LogError("OnCollisionEnter: null collision");
            return;
        }
        GameObject collisionObject = collision.gameObject;

        if(collisionObject.tag == "Enemy")
        {
            collisionObject.SendMessage("ApplyDamage", damage, 
                SendMessageOptions.DontRequireReceiver);
            collisionObject.SendMessage("ApplyKnockback", myRigidbody.velocity.normalized,
                SendMessageOptions.DontRequireReceiver);
            hasCollided = true;
            Destroy(bulletGeom);
        }
    }
}
