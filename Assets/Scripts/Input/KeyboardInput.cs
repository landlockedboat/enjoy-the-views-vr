using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField]
    string fireKey = "space";
    [SerializeField]
    string reloadKey = "r";

    InputHandler inputHandlerInstance;

    void Awake()
    {
        inputHandlerInstance = InputHandler.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            // This triggers firing
            inputHandlerInstance.OnFirePressed();
        }
        if (Input.GetKeyDown(reloadKey))
        {
            inputHandlerInstance.OnReloadPressed();
        }
    }
}
