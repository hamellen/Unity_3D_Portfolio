using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Stat {

    public string name;
    public int hp;
    public int attack;
   
}
[Serializable]
public class StatData {

    public List<Stat> stats = new List<Stat>();


}

public class DataManager 
{

    public Dictionary<string, Stat> StatDict { get; private set; } = new Dictionary<string, Stat>();

    public void Init()
    {
        TextAsset asset=Manager.RESOURCES.Load<TextAsset>($"Data/PlayerStat");
        StatData data = JsonUtility.FromJson<StatData>(asset.text);

        foreach (Stat stat in data.stats) { //µÒº≈≥ ∏Æø° µ•¿Ã≈Õ ª¿‘∞˙¡§

            StatDict.Add(stat.name, stat);
        
        }

    }
}
