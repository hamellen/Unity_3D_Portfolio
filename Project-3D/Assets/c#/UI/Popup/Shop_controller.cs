using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Shop_controller : MonoBehaviour
{

   

    public TextMeshProUGUI text_player_coin;
    public List<int> price_list = new List<int>();
    public Buy_Slot[] SLOTS;

    PlayerController player_controller;
    // Start is called before the first frame update
    void Start()
    {

        
        SLOTS = GetComponentsInChildren<Buy_Slot>();

        for (int i = 0; i < SLOTS.Length; i++) {

            SLOTS[i].Update_State(price_list[i]);
        }
        player_controller = FindObjectOfType<PlayerController>();
        player_controller.gold_event += Update_gold;
        text_player_coin.text = $"{player_controller.stat.GOLD}";
    }

    public void Clsoe_shop() {

        Manager.UI.ClosePopUp();
    }

    public void Buy_Item(int id)
    {
       
        if (player_controller.stat.GOLD >= SLOTS[id].price) {
            Manager.ITEMMANAGER.Apply_Update_Consumer(id);
            player_controller.ApplyEvent(Define.Player_type.GOLD, -SLOTS[id].price);
        }
        
    }

    public void Update_gold() {

        text_player_coin.text = $"{player_controller.stat.GOLD}";
    }
}
