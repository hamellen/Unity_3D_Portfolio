using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{

    public Action consumer;


    public Dictionary<int, IMAGE_ITEM> consumer_dic = new Dictionary<int, IMAGE_ITEM>();

    public int weapon_id = 0;
    public int armor_id = 0;
    

    public Dictionary<int, Weapon_eq> weapon_dic = new Dictionary<int, Weapon_eq>();

    public Dictionary<int, Armor_eq> armor_dic = new Dictionary<int, Armor_eq>();

    public void Init() {


        for (int i = 0; i < Manager.DATAMANAGER.image_item_list.Count; i++) {

            consumer_dic.Add(i, Manager.DATAMANAGER.image_item_list[i]);
       
        }


    }

    public void Apply_Update_Consumer(int id) {

        consumer_dic[id].count++;
        consumer();

    }
}
