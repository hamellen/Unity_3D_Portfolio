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

    public AudioClip click_sfx;
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
        if (IsUse)
        {
            use_image.enabled = true;

        }
        eq_image.sprite = equipment.d3_item.image;
        
    }

    public void Use() {

        if (id == -1)
        {
            Debug.Log("비어있는 슬롯");
            return;
        }
        Manager.ITEMMANAGER.Equip_activate(id, equipment_type);
        Play_sfx();
        Debug.Log("장비 착용 사용");
    }

    public void DeActive()
    {
        eq_image.enabled = false;
        use_image.enabled = false;
        id = -1;
       
    }
    public void Play_sfx()
    {

        Manager.SOUNDMANAGER.Play(Define.Sound.D2_Effect, click_sfx, 1.0f);
    }
    public void Active() {

        eq_image.enabled = true;
    }
}
