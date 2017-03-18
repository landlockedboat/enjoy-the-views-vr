using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRTouchRight : MonoBehaviour {
    [SerializeField]
    float followSpeed = 10f;
    [SerializeField]
    Transform ovrTouchRightPivot;
    [SerializeField]
    float closeEnoughSquared;
	// Use this for initialization
	void Start () {
        transform.position = ovrTouchRightPivot.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(Vector3.SqrMagnitude(
            transform.position - ovrTouchRightPivot.position) > closeEnoughSquared)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, ovrTouchRightPivot.position, followSpeed * Time.deltaTime);
        }
        transform.localRotation = ovrTouchRightPivot.localRotation;
    }
}
