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
    bool gameOver = false;

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

    void InstantiatePrefab(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject instancedPrefab =
            Instantiate(prefab, position, rotation);
        instancedPrefab.transform.localScale = transform.localScale;
    }

    void Start()
    {
        inputHandlerInstance = InputHandler.Instance;
        inputHandlerInstance.RegisterOnFireCallback(Fire);
        inputHandlerInstance.RegisterOnReloadCallback(Reload);
        GameMaster.Instance.RegisterOnGameOverCallback(GameOver);
    }

    void GameOver()
    {
        gameOver = true;
    }

    public void Reload()
    {
        if (gameOver)
            return;

        if(currentAmmo > 0)
        {
            InstantiatePrefab(magazinePrefab, magazineBasePivot.transform.position,
                    magazineBasePivot.transform.rotation);
        }
        currentAmmo = maxAmmo;
        ShowMagazine();
    }

    public virtual void Fire()
    {
        if (gameOver)
            return;

        if (currentAmmo <= 0)
        {
            return;
        }
        // This is only for debugging purposes
        Debug.DrawLine(barrelPivot.transform.position,
                barrelPivot.transform.position + transform.right * -1 * rayLength);

        --currentAmmo;
        if (currentAmmo <= 0)
        {
            HideMagazine();
            InstantiatePrefab(magazinePrefab, magazineBasePivot.transform.position,
                    magazineBasePivot.transform.rotation);
        }
        InstantiatePrefab(shellPrefab, ejectionPortPivot.transform.position,
                    ejectionPortPivot.transform.rotation);
        InstantiatePrefab(bulletPrefab, barrelPivot.transform.position,
            barrelPivot.transform.rotation);
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
