using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{

    
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        boxcollider.enabled = false;
    }

    // Update is called once per frame
    public override void Active_weapon() {

        Debug.Log("Axe 활성화");

        boxcollider.enabled = true;
    }

    public override void DeActive_weapon() {

        Debug.Log("Axe 비활성화");

        boxcollider.enabled = false;

    }
}
