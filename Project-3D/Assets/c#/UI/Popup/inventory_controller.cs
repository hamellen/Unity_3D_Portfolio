using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class inventory_controller : MonoBehaviour
{

    public GameObject con_slot;
    public GameObject equ_slot;

    ItemManager itemManager;

    public Slot_con[] slot_con_array;
    public Slot_eq[] slot_equ_array;
    private void Start()
    {
        con_slot.SetActive(true);
        equ_slot.SetActive(false);

        itemManager = Manager.ITEMMANAGER;

        slot_con_array = GetComponentsInChildren<Slot_con>();
        slot_equ_array = GetComponentsInChildren<Slot_eq>();

        Debug.Log($"consumer active slot count : {Manager.ITEMMANAGER.consumer_dic.Count}");

        foreach(Slot_con slot_con in slot_con_array) {

            slot_con.DeActive();
        }

        for (int i = 0; i < itemManager.consumer_dic.Count; i++) {

            IMAGE_ITEM consumer_itemdata;

            if (itemManager.consumer_dic.TryGetValue(i,out consumer_itemdata))
            {
                if (consumer_itemdata.count > 0) {

                    slot_con_array[i].State_Update(consumer_itemdata);
                }
            }
        }
    }

    public void event_click_equ() {

        con_slot.SetActive(false);
        equ_slot.SetActive(true);
    }
    public void event_click_con()
    {
        con_slot.SetActive(true);
        equ_slot.SetActive(false);
    }

    public void close() {

        Manager.UI.ClosePopUp();
    }
}
