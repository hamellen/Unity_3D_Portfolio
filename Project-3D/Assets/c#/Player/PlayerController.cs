using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public delegate void DamageDelegate();
    public event DamageDelegate damage_event;


    public delegate void GoldDelegate();
    public event DamageDelegate gold_event;

    private Animator animator;

    private PlayerInput playerinput;

    public Weapon weapon;

    public PLAYER_STAT player_stat;
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


        Debug.Log("ÄÞº¸ °ø°Ý");
        animator.SetTrigger("Skill");
        weapon.Active_weapon();

    }

    public void ApplayDamage(int damage) {

        player_stat.HP = Mathf.Clamp(player_stat.HP - damage, 0, player_stat.MAXHP);
        damage_event();
    }

    public void ApplyGold(int gold) {

        player_stat.GOLD += gold;
        gold_event();
    }


    public void End_Attack() {

        weapon.DeActive_weapon();
    }
    public void FootStep() {


        Manager.SOUNDMANAGER.Play_Position(transform.position, "SFX/Footsteps - Essentials/Footsteps_Grass/Footsteps_Grass_Run/Footsteps_Grass_Run_11",2.0f);
        Debug.Log("¶Ñ¹÷");
    
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player_stat = GetComponent<PLAYER_STAT>();
    }

    // Update is called once per frame
    void Update()
    {

       

    }
}
