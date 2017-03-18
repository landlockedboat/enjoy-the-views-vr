using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class stores the information about what has been pressed
// (or is being pressed). You'll need to call this script from a
// specific Input handling behaviour if you want to see any results
public class InputHandler : Singleton<InputHandler> {

    private Action onFireCallback;

    public void RegisterOnFireCallback(Action onFireCallback)
    {
        this.onFireCallback += onFireCallback;
    }

    public void UnregisterOnFireCallback(Action onFireCallback)
    {
        this.onFireCallback -= onFireCallback;
    }

    public void OnFirePressed() {
        // All callbacks associated with this action are executed
        onFireCallback();
    }
}
