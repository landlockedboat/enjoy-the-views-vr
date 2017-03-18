using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : MonoBehaviour {
    [SerializeField]
    GameObject muzzle;

    [Header("Debug options")]
    [SerializeField]
    float rayLength = 200;

    InputHandler inputHandlerInstance;

    void Start()
    {
        inputHandlerInstance = InputHandler.Instance;
        inputHandlerInstance.RegisterOnFireCallback(Fire);
    }

    public void Fire()
    {
        // This is only for debugging purposes
        Debug.DrawLine(muzzle.transform.position,
                muzzle.transform.position + transform.right * -1 * rayLength);
        // Raycasting done here
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, transform.right * -1, out hit))
        {
            Debug.Log("Raycast detected object: " + hit.transform.gameObject.name);
            
        }
    }
}
