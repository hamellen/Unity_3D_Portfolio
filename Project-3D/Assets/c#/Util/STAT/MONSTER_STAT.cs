using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Monster_stat", menuName = "Scriptable/Monster_stat")]
public class Monster_Stat : ScriptableObject
{
    public float HP;
    public float MAXHP;
    public int ATTACK;
    public int DEFENCE;
    public int SPEED;
    public int GOLD;
}
