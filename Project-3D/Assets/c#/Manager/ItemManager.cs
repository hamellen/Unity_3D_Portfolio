using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ItemManager;

public class ItemManager
{
   // public delegate void Consumer_Action();
    public Action consumer_action;

   // public delegate void Equipment_Action();
    public Action equipment_action;

    public delegate void UpdateEquip(int index, Define.Equipment equipment);
    public event UpdateEquip update_equip;

    public Equipment current_weapon;
    public Equipment current_armor;


    public delegate void ActiveConsumer(Define.Player_type type, int figure);
    public event ActiveConsumer activeconsumer;

    public Dictionary<int, IMAGE_ITEM> consumer_dic = new Dictionary<int, IMAGE_ITEM>();

    public int weapon_index = 0;
    public int armor_index = 0;

    public int max_slot = 16;

    public Dictionary<int, Weapon_eq> weapon_dic = new Dictionary<int, Weapon_eq>();

    public Dictionary<int, Armor_eq> armor_dic = new Dictionary<int, Armor_eq>();

    public void Init() {


        for (int i = 0; i < Manager.DATAMANAGER.image_item_list.Count; i++) {

            consumer_dic.Add(i, Manager.DATAMANAGER.image_item_list[i]);
       
        }

        
    }

    public void Apply_Update_Consumer(int id) {//�Һ��� �׵�� 

        consumer_dic[id].count++;
        consumer_action();

    }

    public void Equip_activate(int index,Define.Equipment equipment) {

        if (equipment == Define.Equipment.Weapon)
        {
            current_weapon = weapon_dic[index];
            update_equip(index, equipment);
            Debug.Log("���� ���� ");

        }
        else if (equipment == Define.Equipment.Armor) {

            current_armor = armor_dic[index];
            update_equip(index, equipment);
            Debug.Log("�� ����");
        }
    
    }

    public void Use_Consumer(Define.Consumable consumable, int id) {//�Һ��� ���� 

        if (consumable == Define.Consumable.Healing)//����
        {
            activeconsumer(Define.Player_type.HEALING, consumer_dic[id].figure);//ȿ������
            //consumer_dic[id].count= Mathf.Clamp(consumer_dic[id].count--, 0,999); ;//�������� 
            consumer_dic[id].count--;
            if (consumer_dic[id].count == -1) {
                consumer_dic[id].count = 0;
            }
            Debug.Log($"{consumer_dic[id].count}");
            consumer_action();//�κ��丮 ������Ʈ 
        }
    }

    public void Add_Equipment_Dic(Define.Equipment equipment) {

        if (weapon_dic.Count + armor_dic.Count >= max_slot) {

            Debug.Log("��� �κ��丮 ������");
            return;
        }

        if (equipment == Define.Equipment.Weapon)
        {
            Debug.Log("���� ���� ������Ʈ");
            Weapon_eq weapon_eq = new Weapon_eq();
            weapon_eq.equ_id = weapon_index;
            weapon_eq.equipment_type = Define.Equipment.Weapon;
            weapon_eq.figure = 50;///������ ����
            weapon_eq.d3_item = Manager.RESOURCES.Load<D3_ITEM>("Scriptable/equipment/Axe");
            weapon_dic.Add(weapon_index, weapon_eq);
            weapon_index++;
        }
        else if (equipment == Define.Equipment.Armor)
        {
            Debug.Log("�� ���� ������Ʈ");
            Armor_eq armor_eq = new Armor_eq();
            armor_eq.equ_id = armor_index;
            armor_eq.equipment_type = Define.Equipment.Armor;
            armor_eq.figure = 50;///������ ����
            armor_eq.d3_item = Manager.RESOURCES.Load<D3_ITEM>("Scriptable/equipment/Dragon_Armor");
            armor_dic.Add(weapon_index, armor_eq);
            armor_index++;

        }
        equipment_action();
    }
}
