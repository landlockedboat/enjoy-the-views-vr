using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnFire : MonoBehaviour {
    Animation anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        InputHandler.Instance.RegisterOnFireCallback(Animate);
	}

    void Animate()
    {
        if (WeaponHandler.Instance.GetCurrentAmmo() <= 0)
            return;
        if(anim.IsPlaying("Shot"))
            anim.Stop();
        anim.Play();
    }
	
}
