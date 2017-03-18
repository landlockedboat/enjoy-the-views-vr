using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    float maxHealth = 10f;

    public void ApplyDamage(float ammount)
    {
        maxHealth -= ammount;
        if(maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
