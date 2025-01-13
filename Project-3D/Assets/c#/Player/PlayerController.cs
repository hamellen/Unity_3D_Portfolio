using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    
    public Action hp_event;
    public Action gold_event;

    private Animator animator;

    private PlayerInput playerinput;

    public Weapon weapon;//무기 피격 탐지용

    public Player_Stat1 stat;

    public GameObject inventory_obj;

    //public PLAYER_STAT player_stat;
    //public Equipment current_weapon;
    //public Equipment current_armor;

    public ParticleSystem heal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerinput = new PlayerInput();
        weapon = GetComponentInChildren<Weapon>();

        //foot_sfx = Manager.RESOURCES.Load<AudioClip>("SFX/Footsteps - Essentials/Footsteps_Grass/Footsteps_Grass_Run/Footsteps_Grass_Run_11");
    }

    private void OnEnable()
    {
        
    }

    public void Skill_Attack() {


        Debug.Log("콤보 공격");
        animator.SetTrigger("Skill");
        weapon.Active_weapon();

    }

    public void ApplayDamage(int damage) {

        stat.HP = Mathf.Clamp(stat.HP - damage, 0, stat.MAXHP);
        hp_event();
    }

    

    public void ApplyEvent(Define.Player_type type, int figure) {

        if (type == Define.Player_type.GOLD)
        {

            Manager.DATAMANAGER.player_stat.GOLD += figure;
            gold_event();
        }
        else if (type == Define.Player_type.DAMAGE)
        {

            stat.HP = Mathf.Clamp(stat.HP - figure, 0, stat.MAXHP);
            hp_event();
        }
        else if (type == Define.Player_type.HEALING) {

            stat.HP = Mathf.Clamp(stat.HP + figure, 0, stat.MAXHP);
            
            heal.Stop();
            heal.Play();
            hp_event();
        }
    
    }


    public void End_Attack() {

        weapon.DeActive_weapon();
    }
    public void FootStep() {


        Manager.SOUNDMANAGER.Play_Position(transform.position, "SFX/Footsteps - Essentials/Footsteps_Grass/Footsteps_Grass_Run/Footsteps_Grass_Run_11",2.0f);
       
    
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stat = Manager.DATAMANAGER.player_stat;
        heal.Stop();
        Manager.ITEMMANAGER.activeconsumer += ApplyEvent;

        if (Manager.ITEMMANAGER.current_weapon == null) {

            Debug.Log("장착 무기 없음");
        }
        if (Manager.ITEMMANAGER.current_armor == null) {
            Debug.Log("장착 방어구 없음");
        }
    }

    // Update is called once per frame
    void Update()
    {

       

    }
}
