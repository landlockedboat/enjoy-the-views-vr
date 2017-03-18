using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : Singleton<WeaponHandler>
{
    [Header("Read only variables")]
    [SerializeField]
    ShootingWeapon[] shootingWeapons;
    [Header("Weapon Configuration")]
    [SerializeField]
    int currentWeapon = 0;

    InputHandler inputHandlerInstance;

    void DeactivateWeapon(int index)
    {
        shootingWeapons[index].gameObject.SetActive(false);
    }

    void ActivateWeapon(int index)
    {
        shootingWeapons[index].gameObject.SetActive(true);
    }

    void Awake()
    {
        shootingWeapons = GetComponentsInChildren<ShootingWeapon>();
    }

    void Start()
    {
        inputHandlerInstance = InputHandler.Instance;

        inputHandlerInstance.RegisterOnNextWeaponCallback(NextWeapon);
        inputHandlerInstance.RegisterOnPreviousWeaponCallback(PreviousWeapon);

        for (int i = 0; i < shootingWeapons.Length; i++)
        {
            if(i != currentWeapon)
            {
                DeactivateWeapon(i);
            }
        }
    }

    public void NextWeapon()
    {
        ++currentWeapon;
        if(currentWeapon >= shootingWeapons.Length)
        {
            currentWeapon = 0;
            DeactivateWeapon(shootingWeapons.Length - 1);
        }
        else
        {
            DeactivateWeapon(currentWeapon - 1);
        }
        ActivateWeapon(currentWeapon);
    }

    public void PreviousWeapon()
    {
        --currentWeapon;
        if (currentWeapon < 0)
        {
            currentWeapon = shootingWeapons.Length - 1;
            DeactivateWeapon(0);
        }
        else
        {
            DeactivateWeapon(currentWeapon + 1);
        }
        ActivateWeapon(currentWeapon);
    }

    public int GetCurrentAmmo()
    {
        if (shootingWeapons.Length <= 0)
        {
            return 0;
        }
        return shootingWeapons[currentWeapon].CurrentAmmo;
    }

    public int GetMaxAmmo()
    {
        if (shootingWeapons.Length <= 0)
        {
            return 0;
        }
        return shootingWeapons[currentWeapon].MaxAmmo;
    }

}
