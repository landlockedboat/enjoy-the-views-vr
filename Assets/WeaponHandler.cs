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

    void Start()
    {
        shootingWeapons = GetComponentsInChildren<ShootingWeapon>();
    }

    public void NextWeapon()
    {
        Debug.LogError("NextWeapon not implemented");
    }

    public void PreviousWeapon()
    {
        Debug.LogError("PreviousWeapon not implemented");
    }

    public int GetCurrentAmmo()
    {
        return shootingWeapons[currentWeapon].CurrentAmmo;
    }

    public int GetMaxAmmo()
    {
        return shootingWeapons[currentWeapon].MaxAmmo;
    }

}
