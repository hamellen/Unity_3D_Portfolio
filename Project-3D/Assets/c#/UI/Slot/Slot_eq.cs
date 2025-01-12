using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_eq : MonoBehaviour
{
    public Define.Equipment equipment_type;
    public int id;
    public Image eq_image;
    public Image use_image;
    public bool IsUse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void State_Update(Equipment equipment)
    {

        Debug.Log("장비 슬롯 업데이트 ");
        Active();
        equipment_type = equipment.equipment_type;
        id = equipment.equ_id;

        eq_image.sprite = equipment.d3_item.image;
        
    }

    public void Use() { 
    
        
    }

    public void DeActive()
    {
        eq_image.enabled = false;
        
        id = -1;
       
    }

    public void Active() {

        eq_image.enabled = true;
    }
}
