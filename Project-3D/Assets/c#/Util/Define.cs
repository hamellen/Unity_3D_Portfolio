using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{

    public enum Scene {
    
        Unknown,Login,Lobby,Game//로그인 ,로비,본게임
    }


    public enum Sound { 
    
        Bgm,D2_Effect,MaxCount
    
    }

    public enum Weapon { 
    
        Sword,Axe,MaxCount
    }

    public enum Grade { 
        Normal,Rare,Unique,Epic,Legend
    }
    
    public enum Effect { 
        Healing   
     }

}
