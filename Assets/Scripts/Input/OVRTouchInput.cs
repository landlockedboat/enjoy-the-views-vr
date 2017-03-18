using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRTouchInput : MonoBehaviour {
    InputHandler inputHandlerInstance;

    bool isFirePressed = false;

    void Start() {
        inputHandlerInstance = InputHandler.Instance;
    }

    void Update () {

        if ( !isFirePressed && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
        {
            isFirePressed = true;
            inputHandlerInstance.OnFirePressed();
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 0)
        {
            isFirePressed = false;
        }
    }
}
