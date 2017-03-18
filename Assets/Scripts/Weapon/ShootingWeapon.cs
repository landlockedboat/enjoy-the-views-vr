using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : MonoBehaviour {
    [Header("Weapon Variables")]
    [SerializeField]
    int maxAmmo = 10;

    [Header("Game Object Configuration")]
    [SerializeField]
    GameObject barrelPivot;
    [SerializeField]
    GameObject ejectionPortPivot;
    [SerializeField]
    GameObject magazineBasePivot;
    [SerializeField]
    GameObject magazineGeom;

    [Header("Prefabs")]
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject shellPrefab;
    [SerializeField]
    GameObject magazinePrefab;

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
        if(currentAmmo > 0)
        {
            Debug.Log("Recharging while the mag is still full");
            GameObject magazine =
                Instantiate(magazinePrefab, magazineBasePivot.transform.position,
                    magazineBasePivot.transform.rotation);

        }
        currentAmmo = maxAmmo;
        ShowMagazine();
    }

    public virtual void Fire()
    {
        if (currentAmmo <= 0)
        {
            return;
        }
        // This is only for debugging purposes
        Debug.DrawLine(barrelPivot.transform.position,
                barrelPivot.transform.position + transform.right * -1 * rayLength);

        --currentAmmo;
        if(currentAmmo <= 0)
        {
            HideMagazine();
            GameObject magazine =
                Instantiate(magazinePrefab, magazineBasePivot.transform.position,
                    magazineBasePivot.transform.rotation);
        }
        GameObject shell = 
            Instantiate(shellPrefab, ejectionPortPivot.transform.position,
                ejectionPortPivot.transform.rotation);
        GameObject bullet =
            Instantiate(bulletPrefab, barrelPivot.transform.position, Quaternion.identity);
    }

    void ShowMagazine()
    {
        if (magazineGeom != null)
        {
            // We do this check because not all guns will have a visible mag
            magazineGeom.SetActive(true);
        }
    }

    void HideMagazine()
    {
        if(magazineGeom != null)
        {
            // We do this check because not all guns will have a visible mag
            magazineGeom.SetActive(false);
        }
    }
}
