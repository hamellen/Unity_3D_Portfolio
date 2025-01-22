using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cysharp.Threading.Tasks;
using UnityEditor.Rendering;
using Cinemachine;
//using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerController : MonoBehaviour
{

    
    public Action hp_event;
    public Action gold_event;
    Movement3d movement3D;
    private Animator animator;
   
    //private PlayerInput playerinput;

    public Weapon weapon;//무기 피격 탐지용

    public Player_Stat1 stat;

    public GameObject inventory_obj;

    public CinemachineFreeLook free_camera;

    bool IsMerchant = false;
    public AudioClip heal_sfx;
    public AudioClip attack_sfx;
    //public PLAYER_STAT player_stat;
    //public Equipment current_weapon;
    //public Equipment current_armor;

    public ParticleSystem heal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //playerinput = new PlayerInput();
        weapon = GetComponentInChildren<Weapon>();
        
        //foot_sfx = Manager.RESOURCES.Load<AudioClip>("SFX/Footsteps - Essentials/Footsteps_Grass/Footsteps_Grass_Run/Footsteps_Grass_Run_11");
    }

   

    public void Skill_Attack() {


        Debug.Log("콤보 공격");
        animator.SetTrigger("Skill");
        Manager.SOUNDMANAGER.Play(Define.Sound.D2_Effect, attack_sfx, 1.0f);
        weapon.Active_weapon();
        movement3D.CanMove = false;
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

            PlayVfxHeal().Forget();
            Manager.SOUNDMANAGER.Play(Define.Sound.D2_Effect, heal_sfx, 1.0f);
            hp_event();
        }
    
    }

   

    public void End_Attack() {

        weapon.DeActive_weapon();
        movement3D.CanMove = true;
    }
    public void FootStep() {


        Manager.SOUNDMANAGER.Play_Position(transform.position, "SFX/Footsteps - Essentials/Footsteps_Grass/Footsteps_Grass_Run/Footsteps_Grass_Run_11",2.0f);
       
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster_Attack") {

            ApplyEvent(Define.Player_type.DAMAGE, other.gameObject.GetComponent<Weapon>().damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stat = Manager.DATAMANAGER.player_stat;
        heal.Stop();
        Manager.ITEMMANAGER.activeconsumer += ApplyEvent;
        movement3D = GetComponent<Movement3d>();

        if (Manager.ITEMMANAGER.current_weapon == null) {

            Debug.Log("장착 무기 없음");
        }
        if (Manager.ITEMMANAGER.current_armor == null) {
            Debug.Log("장착 방어구 없음");
        }

       
        //free_camera.m_XAxis.VA
    }

    public async UniTaskVoid PlayVfxHeal() {
        
        heal.Play();
        await UniTask.Delay(2000);
        heal.Stop();
    }

    // Update is called once per frame
    void Update()
    {

       

    }
}
