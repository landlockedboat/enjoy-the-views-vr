using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class stores the information about what has been pressed
// (or is being pressed). You'll need to call this script from a
// specific Input handling behaviour if you want to see any results
public class InputHandler : Singleton<InputHandler> {

    Action onFireCallback;
    Action postFireCallback;

    Action onReloadCallback;
    Action postReloadCallback;

    Action onNextWeaponCallback;

    Action onPreviousWeaponCallback;

    Action onMagazineCallback;
    Action onMagazineReleasedCallback;

    //onMagazineCallback
    public void RegisterOnMagazineCallback(Action onMagazineCallback)
    {
        this.onMagazineCallback += onMagazineCallback;
    }

    public void OnMagazinePressed()
    {
        TriggerCallback(onMagazineCallback);
    }

    //onMagazineReleasedCallback
    public void RegisterOnMagazineReleasedCallback(Action onMagazineReleasedCallback)
    {
        this.onMagazineReleasedCallback += onMagazineReleasedCallback;
    }

    public void OnMagazineReleased()
    {
        TriggerCallback(onMagazineReleasedCallback);
    }



    //onNextWeaponCallback
    public void RegisterOnNextWeaponCallback(Action onNextWeaponCallback)
    {
        this.onNextWeaponCallback += onNextWeaponCallback;
    }

    public void OnNextWeaponPressed()
    {
        TriggerCallback(onNextWeaponCallback);
    }

    // onPreviousWeaponCallback
    public void RegisterOnPreviousWeaponCallback(Action onPreviousWeaponCallback)
    {
        this.onPreviousWeaponCallback += onPreviousWeaponCallback;
    }

    public void OnPreviousWeaponPressed()
    {
        TriggerCallback(onPreviousWeaponCallback);
    }

    // onFireCallback
    public void RegisterOnFireCallback(Action onFireCallback)
    {
        this.onFireCallback += onFireCallback;
    }

    public void RegisterPostFireCallback(Action postFireCallback)
    {
        this.postFireCallback += postFireCallback;
    }

    public void UnregisterOnFireCallback(Action onFireCallback)
    {
        this.onFireCallback -= onFireCallback;
    }

    public void OnFirePressed() {
        TriggerCallback(onFireCallback);
        TriggerCallback(postFireCallback);
    }

    // onReloadCallback
    public void RegisterOnReloadCallback(Action onReloadCallback)
    {
        this.onReloadCallback += onReloadCallback;
    }

    public void RegisterPostReloadCallback(Action postReloadCallback)
    {
        this.postReloadCallback += postReloadCallback;
    }

    public void UnregisterOnReloadCallback(Action onReloadCallback)
    {
        this.onReloadCallback -= onReloadCallback;
    }

    public void OnReloadPressed()
    {
        TriggerCallback(onReloadCallback);
        TriggerCallback(postReloadCallback);
    }

    void TriggerCallback(Action callback)
    {
        if(callback != null)
        {
            callback();
        }
    }
}
