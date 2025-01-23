using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player_stat", menuName = "Scriptable/Player_stat")]

public class Player_Stat1 : ScriptableObject
{
    public int LEVEL;
    public float HP;
    public float MAXHP;
    public int ATTACK;
    public int DEFENCE;
    public int SPEED;
    public int EXP;  // °æÇèÄ¡
    public int GOLD ; // È×µæÀçÈ­
    public int Cash;
    public int Asked_max_exp;
}
