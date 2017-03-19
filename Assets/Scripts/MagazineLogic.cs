using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineLogic : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Magazine")
        {
            InputHandler.Instance.OnReloadPressed();
        }
    }


}
