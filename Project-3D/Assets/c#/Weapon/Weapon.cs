using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Define.Weapon weapon;
    
    public BoxCollider boxcollider;
    

    public abstract void Active_weapon();
    public abstract void DeActive_weapon();

}
