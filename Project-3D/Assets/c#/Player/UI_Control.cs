using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.UIElements;



public class UI_Control : MonoBehaviour, IPointerUpHandler
{

    private PlayerController playercontroller;
    private NormalAttack normal_attack;

    public TextMeshProUGUI gold;//무료 재화
    public TextMeshProUGUI cash;//유료 재화

    public Slider hp_slider;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller = FindObjectOfType<PlayerController>();
        normal_attack = FindObjectOfType<NormalAttack>();

        playercontroller.damage_event += Update_Hp;
        playercontroller.gold_event += Update_Gold;
        gold.text = $"{playercontroller.player_stat.GOLD}";
        cash.text = $"{playercontroller.player_stat.Cash}";

        hp_slider.value = (playercontroller.player_stat.HP / playercontroller.player_stat.MAXHP);
    }

    public void Normal_Attack()
    {
        playercontroller.Skill_Attack();
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

        hp_slider.value = (playercontroller.player_stat.HP / playercontroller.player_stat.MAXHP);
    }

    void Update_Gold() {
        gold.text = $"{playercontroller.player_stat.GOLD}";
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("터치 종료 ");
    }
}
