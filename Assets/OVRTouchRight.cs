﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRTouchRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        Debug.Log(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch));
	}
}
