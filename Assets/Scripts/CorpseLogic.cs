using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseLogic : MonoBehaviour {

    [SerializeField]
    Transform leftLeg;
    [SerializeField]
    Transform rightLeg;

    public void InitLeftLeg(Quaternion leftLegRot)
    {
        leftLeg.rotation = leftLegRot;
    }

    public void InitRightLeg(Quaternion rightLegRot)
    {
        rightLeg.rotation = rightLegRot;
    }

}
