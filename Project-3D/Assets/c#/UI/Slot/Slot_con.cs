using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Slot_con;

public class Slot_con : MonoBehaviour
{
    


    public Define.Consumable consume_type;
    public int id;
    public int count;

    public Image con_image;
    public TextMeshProUGUI figure_count;
    public AudioClip click_sfx;
    public void State_Update(IMAGE_ITEM itemdata)
    {

        Debug.Log("소비품 슬롯 업데이트 ");
        Active();
        consume_type = itemdata.consumable;
        id = itemdata.id;
        count= itemdata.count;
        con_image.sprite = itemdata.image;
        figure_count.text = $"{itemdata.count}";
    }

    public void Active() {

        con_image.enabled = true;
        figure_count.enabled = true;
    }

    public void Use() {

        if (id == -1) {
            Debug.Log("비어있는 슬롯");
            return;
        }
        Manager.ITEMMANAGER.Use_Consumer(consume_type, id);
        Play_sfx();
        Debug.Log("소비재 사용");
    
    }

    public void Play_sfx()
    {

        Manager.SOUNDMANAGER.Play(Define.Sound.D2_Effect, click_sfx, 1.0f);
    }
    public void DeActive()
    {
        con_image.enabled = false;
        figure_count.enabled = false;
        id = -1; 
        count = 0;

    }
}
