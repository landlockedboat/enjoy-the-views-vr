using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : MonoBehaviour {
    [Header("Weapon Variables")]
    [SerializeField]
    int maxAmmo = 10;
    [SerializeField]
    float damage = 5f;

    [Header("Game Object Configuration")]
    [SerializeField]
    GameObject muzzle;

    [Header("Debug options")]
    [SerializeField]
    float rayLength = 200;

    int currentAmmo;
    InputHandler inputHandlerInstance;

    public int CurrentAmmo
    {
        get
        {
            return currentAmmo;
        }
    }

    public int MaxAmmo
    {
        get
        {
            return maxAmmo;
        }
    }

    void Awake()
    {
        // I'm doing this in here because of the UI
        // (and other stuff later on, probably)
        currentAmmo = maxAmmo;
    }

    void Start()
    {
        inputHandlerInstance = InputHandler.Instance;
        inputHandlerInstance.RegisterOnFireCallback(Fire);
        inputHandlerInstance.RegisterOnReloadCallback(Reload);
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
    }

    public virtual void Fire()
    {
        if (currentAmmo <= 0)
        {
            return;
        }
        // This is only for debugging purposes
        Debug.DrawLine(muzzle.transform.position,
                muzzle.transform.position + transform.right * -1 * rayLength);
        // Raycasting done here
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, transform.right * -1, out hit))
        {
            FireHit(hit);
        }
        --currentAmmo;
    }

    protected virtual void FireHit(RaycastHit hit)
    {
        Debug.Log("Raycast detected object: " + hit.transform.gameObject.name);
    }
}
