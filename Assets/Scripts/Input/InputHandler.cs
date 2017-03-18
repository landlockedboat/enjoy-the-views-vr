using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class stores the information about what has been pressed
// (or is being pressed). You'll need to call this script from a
// specific Input handling behaviour if you want to see any results
public class InputHandler : Singleton<InputHandler> {

    private Action onFireCallback;
    private Action postFireCallback;

    private Action onReloadCallback;
    private Action postReloadCallback;
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
        onFireCallback();
        postFireCallback();
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
        onReloadCallback();
        postReloadCallback();
    }

}
