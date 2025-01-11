using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class inventory_controller : MonoBehaviour
{

    public GameObject con_slot_list;
    public GameObject equ_slot_list;

    ItemManager itemManager;

    public Slot_con[] slot_con_array;
    public Slot_eq[] slot_equ_array;
    private void Start()
    {
        Manager.ITEMMANAGER.consumer += Apply_inventory_consumer_value;

        con_slot_list.SetActive(true);
        equ_slot_list.SetActive(false);

        itemManager = Manager.ITEMMANAGER;

        slot_con_array = GetComponentsInChildren<Slot_con>();
        slot_equ_array = GetComponentsInChildren<Slot_eq>();

        //Debug.Log($"consumer active slot count : {Manager.ITEMMANAGER.consumer_dic.Count}");

        Apply_inventory_consumer_value();

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
    public void Draw_Consumer_slot() {
        for (int i = 0; i < itemManager.consumer_dic.Count; i++)
        {

            IMAGE_ITEM consumer_itemdata;

            if (itemManager.consumer_dic.TryGetValue(i, out consumer_itemdata))
            {
                if (consumer_itemdata.count > 0)
                {

                    slot_con_array[i].State_Update(consumer_itemdata);
                }
            }
        }
    }


    public void Reset_Consumer() {
        foreach (Slot_con slot_con in slot_con_array)
        {

            slot_con.DeActive();
        }
    }
    public void close() {

        Manager.UI.ClosePopUp();
    }
}
