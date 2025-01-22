using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.UIElements;



public class UI_Control : MonoBehaviour
{

    private PlayerController playercontroller;
    private NormalAttack normal_attack;

    public TextMeshProUGUI gold;//무료 재화
    public TextMeshProUGUI cash;//유료 재화

    public AudioClip click_sfx;

    bool IsInventoryOpen = false;

    public GameObject Btn_merchant;
    bool IsMerchant = false;

    public Slider hp_slider;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller = FindObjectOfType<PlayerController>();
        normal_attack = FindObjectOfType<NormalAttack>();
        Manager.UI.MerChantBtn += Interaction_Merchant;
        Manager.UI.InventoryBtn += interact_Inventory;
        playercontroller.hp_event += Update_Hp;
        playercontroller.gold_event += Update_Gold;
        gold.text = $"{playercontroller.stat.GOLD}";
        cash.text = $"{playercontroller.stat.Cash}";

        hp_slider.value = (playercontroller.stat.HP / playercontroller.stat.MAXHP);
        Btn_merchant.SetActive(false);
    }

    public void Normal_Attack()
    {
        playercontroller.Skill_Attack();
        Play_sfx();
    }

    public void dodge() {

        normal_attack.AttackCount = 1;
    }

    public void ComboAttack()
    {

        normal_attack.AttackCount = 0;
    }

    public void ActiveSkill()
    {

        normal_attack.AttackCount = 2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Update_Hp() {

        hp_slider.value = (playercontroller.stat.HP / playercontroller.stat.MAXHP);
    }

    void Update_Gold() {
        gold.text = $"{playercontroller.stat.GOLD}";
    }
    public void Interaction_Merchant() {

        if (!IsMerchant)
        {
            Btn_merchant.SetActive(true);
            IsMerchant = true;
        }
        else if (IsMerchant) {
            Btn_merchant.SetActive(false);
            IsMerchant = false;
        }
    }

    public void Show_PauseUI() {

        Manager.UI.ShowPopUI("Pause_UI");
        Play_sfx();
    }
    public void Show_Shop() {

        Manager.UI.ShowPopUI("CashShop");
        Play_sfx();
    }

    public void Play_sfx() {

        Manager.SOUNDMANAGER.Play(Define.Sound.D2_Effect, click_sfx,1.0f);
    }

   
    public void interact_Inventory() {


        if (IsInventoryOpen == false)
        {
            IsInventoryOpen = true;
            playercontroller.inventory_obj.SetActive(true);
            Play_sfx();
        }
        else if (IsInventoryOpen == true) {

            IsInventoryOpen =false;
            playercontroller.inventory_obj.SetActive(false);
            Play_sfx();
        }
        
    }
}
