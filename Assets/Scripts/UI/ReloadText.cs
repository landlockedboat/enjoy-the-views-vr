using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadText : MonoBehaviour {

    [SerializeField]
    GameObject text;
    [SerializeField]
    GameObject magazineGeom;

    InputHandler inputHandlerInstance;

    bool enoughAmmo = true;

    void Start () {
        inputHandlerInstance = InputHandler.Instance;

        inputHandlerInstance.RegisterPostFireCallback(CheckIfNoAmmo);
        inputHandlerInstance.RegisterPostReloadCallback(CheckIfNoAmmo);

        inputHandlerInstance.RegisterOnMagazineCallback(ShowMagazine);
        inputHandlerInstance.RegisterOnMagazineReleasedCallback(HideMagazine);

    }

    void ShowMagazine()
    {
        if (enoughAmmo)
            return;
        text.SetActive(false);
        magazineGeom.SetActive(true);
    }

    void HideMagazine()
    {
        if (enoughAmmo)
            return;
        text.SetActive(true);
        magazineGeom.SetActive(false);
    }

    void CheckIfNoAmmo()
    {
        if(WeaponHandler.Instance.GetCurrentAmmo() > 0)
        {
            text.SetActive(false);
            magazineGeom.SetActive(false);
            enoughAmmo = true;
        }
        else
        {
            text.SetActive(true);
            enoughAmmo = false;
        }
    }
}
