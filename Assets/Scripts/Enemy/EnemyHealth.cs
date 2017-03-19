using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    float maxHealth = 10f;

    [SerializeField]
    GameObject corpsePrefab;

    public void ApplyDamage(float ammount)
    {
        maxHealth -= ammount;
        if(maxHealth <= 0)
        {
            EnemiesKilledUI.Instance.EnemyKilled();
            GameObject corpse =
                Instantiate(corpsePrefab, transform.position, transform.rotation);
            gameObject.SendMessage("Die");
            Destroy(gameObject);
        }
    }
}
