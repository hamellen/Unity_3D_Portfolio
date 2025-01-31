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

  

    public List<IMAGE_ITEM> image_item_list = new List<IMAGE_ITEM>();
    public List<D3_ITEM> d3_item_list = new List<D3_ITEM>();

    public Player_Stat1 player_stat;
    public Monster_Stat warrior_stat;
    public void Init()
    {
       

        image_item_list.Add(Manager.RESOURCES.Load<IMAGE_ITEM>("Scriptable/consume/Normal_Healing"));
        image_item_list.Add(Manager.RESOURCES.Load<IMAGE_ITEM>("Scriptable/consume/Rare_Healing"));
        image_item_list.Add(Manager.RESOURCES.Load<IMAGE_ITEM>("Scriptable/consume/Unique_Healing"));

        d3_item_list.Add(Manager.RESOURCES.Load<D3_ITEM>("Scriptable/equipment/Axe"));//axe
        d3_item_list.Add(Manager.RESOURCES.Load<D3_ITEM>("Scriptable/equipment/Dragon_Armor"));//armor

        player_stat= Manager.RESOURCES.Load<Player_Stat1>("Scriptable/stat/Player_stat");
        warrior_stat= Manager.RESOURCES.Load<Monster_Stat>("Scriptable/stat/Warrior_stat");

       
    }
}
