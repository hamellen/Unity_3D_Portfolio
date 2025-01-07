using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        boxcollider.enabled = false;
    }

    // Update is called once per frame
    public override void Active_weapon()
    {
        
        boxcollider.enabled = true;
    }

    public override void DeActive_weapon()
    {

        boxcollider.enabled = false;

    }
}
