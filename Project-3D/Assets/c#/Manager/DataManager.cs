using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;





[Serializable]
public class Stat {

    public int index;
    public int hp;
    public int maxhp;
    public int attack;
    public int defence;
    public int speed;
}
[Serializable]
public class StatData {

    public List<Stat> stats = new List<Stat>();


}

public class DataManager 
{

    public Dictionary<int, Stat> StatDict { get;  set; } = new Dictionary<int, Stat>();

    public void Init()
    {
        TextAsset asset=Manager.RESOURCES.Load<TextAsset>($"Data/MonsterStat");
        Debug.Log(asset.text);
        StatData data = JsonUtility.FromJson<StatData>(asset.text);

        foreach (Stat stat in data.stats) { //µÒº≈≥ ∏Æø° µ•¿Ã≈Õ ª¿‘∞˙¡§

            StatDict.Add(stat.index, stat);
            Debug.Log($"{stat.index}");
        }

    }
}
