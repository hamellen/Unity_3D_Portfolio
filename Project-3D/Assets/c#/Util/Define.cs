using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{

    public enum Scene {
    
        Unknown,Login,Lobby,Game//�α��� ,�κ�,������
    }

    public enum Monster_State { 
    
        IDLE,ATTACK
    }
    public enum Sound { 
    
        Bgm,D2_Effect,MaxCount
    
    }

    public enum Weapon { 
    
        Sword,Axe,Dagger,MaxCount
    }

    public enum Grade { 
        Normal,Rare,Unique,Epic,Legend
    }
    
    public enum Effect { 
        Healing   
     }

}
