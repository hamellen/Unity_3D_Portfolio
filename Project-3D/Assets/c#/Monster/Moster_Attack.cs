using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moster_Attack : MonoBehaviour
{

    public CapsuleCollider collider;
    public Monster_Controller monster_controller;

    private void Start()
    {
        monster_controller = GetComponentInParent<Monster_Controller>();
        //monster_controller.attack += Update_State;
        collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;//시작시 초기화
    }

    void Update_State(Define.Monster_State state) {

        if (state == Define.Monster_State.ATTACK)
        {
            collider.enabled = true;

        }
        else if (state == Define.Monster_State.IDLE) {
            collider.enabled = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {

            collision.gameObject.GetComponent<PlayerController>().ApplayDamage(monster_controller.monster_stat.ATTACK);
            collider.enabled = false;
        }

    }



}
