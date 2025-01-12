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

    public void State_Update(IMAGE_ITEM itemdata)
    {

        Debug.Log("�Һ�ǰ ���� ������Ʈ ");
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
            Debug.Log("����ִ� ����");
            return;
        }
        Manager.ITEMMANAGER.Use_Consumer(consume_type, id);

        Debug.Log("�Һ��� ���");
    
    }
    public void DeActive()
    {
        con_image.enabled = false;
        figure_count.enabled = false;
        id = -1; 
        count = 0;

    }
}
