using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{

    private PlayerController playercontroller;
    private NormalAttack normal_attack;


    // Start is called before the first frame update
    void Start()
    {
        playercontroller = FindObjectOfType<PlayerController>();
        normal_attack = FindObjectOfType<NormalAttack>();
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
}
