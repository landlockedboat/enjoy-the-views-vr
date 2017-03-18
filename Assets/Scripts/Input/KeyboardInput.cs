using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField]
    string fireKey = "space";

    InputHandler inputHandlerInstance;

    void Awake()
    {
        inputHandlerInstance = InputHandler.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            // This trigger firing
            inputHandlerInstance.OnFirePressed();
        }
    }
}
