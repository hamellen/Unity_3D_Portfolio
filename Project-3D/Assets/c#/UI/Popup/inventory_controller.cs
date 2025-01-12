using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class inventory_controller : MonoBehaviour
{

    public GameObject con_slot_list;
    public GameObject equ_slot_list;

    int current_equ_index;

    public Slot_con[] slot_con_array;
    public Slot_eq[] slot_equ_array;

    private void Awake()
    {
        slot_con_array = GetComponentsInChildren<Slot_con>();
        slot_equ_array = GetComponentsInChildren<Slot_eq>();
    }

    private void Start()
    {
        Manager.ITEMMANAGER.consumer_action += Apply_inventory_consumer_value;
        Manager.ITEMMANAGER.equipment_action += Apply_inventory_equipment_value;


        con_slot_list.SetActive(true);
        equ_slot_list.SetActive(false);

        //Debug.Log($"consumer active slot count : {Manager.ITEMMANAGER.consumer_dic.Count}");

        Apply_inventory_consumer_value();
        Apply_inventory_equipment_value();
    }

    private void OnEnable()
    {
        Apply_inventory_consumer_value();
        Apply_inventory_equipment_value();
    }
    public void event_click_equ() {

        con_slot_list.SetActive(false);
        equ_slot_list.SetActive(true);
    }
    public void event_click_con()
    {
        con_slot_list.SetActive(true);
        equ_slot_list.SetActive(false);
    }

    public void Apply_inventory_consumer_value() {

        Debug.Log("소비품 인벤토리 업데이트 ");

        Reset_Consumer();
        Draw_Consumer_slot();

    }
    public void Apply_inventory_equipment_value()
    {

        Debug.Log("장비  인벤토리 업데이트 ");

        Reset_Equipment();
        Draw_Equipment_slot();

    }

    public void Draw_Consumer_slot() {
        for (int i = 0; i < Manager.ITEMMANAGER.consumer_dic.Count; i++)
        {

            IMAGE_ITEM consumer_itemdata;

            if (Manager.ITEMMANAGER.consumer_dic.TryGetValue(i, out consumer_itemdata))
            {
                if (consumer_itemdata.count > 0)
                {

                    slot_con_array[i].State_Update(consumer_itemdata);
                }
            }
        }
    }

    public void Draw_Equipment_slot()
    {
        current_equ_index = 0;
        for (int i = 0; i < Manager.ITEMMANAGER.weapon_dic.Count; i++) {
            
            Weapon_eq weapon;
            if (Manager.ITEMMANAGER.weapon_dic.TryGetValue(i, out weapon))
            {
                
                slot_equ_array[current_equ_index].State_Update(weapon);
                current_equ_index++;
            }

        }
        for (int i = 0; i < Manager.ITEMMANAGER.armor_dic.Count; i++)
        {

            Armor_eq armor;
            if (Manager.ITEMMANAGER.armor_dic.TryGetValue(i, out armor))
            {
               
                slot_equ_array[current_equ_index].State_Update(armor);
                current_equ_index++;
            }

        }
    }
    public void Reset_Consumer() {
        foreach (Slot_con slot_con in slot_con_array)
        {

            slot_con.DeActive();
        }
    }

    public void Reset_Equipment()
    {
        foreach (Slot_eq slot_equ in slot_equ_array)
        {

            slot_equ.DeActive();
        }
    }
    public void close() {

        gameObject.SetActive(false);
    }

    
}
