using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeaponUI : MonoBehaviour {

    [SerializeField]
    private TextMesh currentAmmoText;

    WeaponHandler weaponHandlerInstance;
    InputHandler inputHandlerInstance;

    void Start()
    {
        inputHandlerInstance = InputHandler.Instance;
        weaponHandlerInstance = WeaponHandler.Instance;

        inputHandlerInstance.RegisterPostFireCallback(UpdateAmmoText);
        inputHandlerInstance.RegisterPostReloadCallback(UpdateAmmoText);

        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        string newText = "Ammo: ";
        newText += weaponHandlerInstance.GetCurrentAmmo() + "/";
        newText += weaponHandlerInstance.GetMaxAmmo();
        currentAmmoText.text = newText;
    }

}
