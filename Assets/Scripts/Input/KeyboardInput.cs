using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField]
    string fireKey = "space";
    [SerializeField]
    string reloadKey = "r";
    [SerializeField]
    string nextWeaponKey = "q";
    [SerializeField]
    string previousWeaponKey = "e";
    [SerializeField]
    string magazineKey = "m";
    [SerializeField]
    string sceneLoadKey = "l";


    InputHandler inputHandlerInstance;

    void Awake()
    {
        inputHandlerInstance = InputHandler.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            inputHandlerInstance.OnFirePressed();
        }
        if (Input.GetKeyDown(reloadKey))
        {
            inputHandlerInstance.OnReloadPressed();
        }
        if (Input.GetKeyDown(nextWeaponKey))
        {
            inputHandlerInstance.OnNextWeaponPressed();
        }
        if (Input.GetKeyDown(previousWeaponKey))
        {
            inputHandlerInstance.OnPreviousWeaponPressed();
        }
        if (Input.GetKeyDown(magazineKey))
        {
            inputHandlerInstance.OnMagazinePressed();
        }
        if (Input.GetKeyUp(magazineKey))
        {
            inputHandlerInstance.OnMagazineReleased();
        }
        if (Input.GetKeyUp(sceneLoadKey))
        {
            inputHandlerInstance.OnReloadScene();
        }
    }
}
