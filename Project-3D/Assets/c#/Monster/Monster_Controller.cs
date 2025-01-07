using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster_Controller : MonoBehaviour
{

    public delegate void Attack_Event(Define.Monster_State state);
    public event Attack_Event attack;

    public List<IMAGE_ITEM> rewards = new List<IMAGE_ITEM>();

    Animator animator;
    NavMeshAgent agent;

    [SerializeField] Transform HpBar;
    [SerializeField] Camera camera;
    [SerializeField] Slider slider;

   
    public MONSTER_STAT monster_stat;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        monster_stat = GetComponent<MONSTER_STAT>();
        agent.speed = monster_stat.SPEED;

        camera = Camera.main;
       

       
        slider = GetComponentInChildren<Slider>();
        

        
        //if (Manager.DATAMANAGER.StatDict.TryGetValue(1,out stat)){

        //    monster_stat.HP = stat.hp;
        //    monster_stat.MAXHP= stat.maxhp;
        //    monster_stat.ATTACK = stat.attack;
        //    monster_stat.DEFENCE = stat.defence;
        //    monster_stat.SPEED = stat.speed;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon") {

            Debug.Log("피격당함");
            monster_stat.HP = Mathf.Clamp(monster_stat.HP-other.gameObject.GetComponent<Weapon>().damage,0, monster_stat.MAXHP);
            slider.value = (monster_stat.HP / monster_stat.MAXHP);
            if (monster_stat.HP == 0) {
                animator.SetBool("IsDead", true);
                FindObjectOfType<PlayerController>().ApplyGold(monster_stat.reward_gold);
                Destroy(gameObject, 5.0f);
            }
        }
    }

    public void Attack() {

        animator.SetTrigger("Monster_Attack");
        attack(Define.Monster_State.ATTACK);
        
    }

    public void ResetAttack() {

        attack(Define.Monster_State.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q_hp = Quaternion.LookRotation(HpBar.transform.position- camera.transform.position);
        Vector3 hp_angle = Quaternion.RotateTowards(HpBar.transform.rotation, q_hp, 100).eulerAngles;
        HpBar.rotation = Quaternion.Euler(0, hp_angle.y, 0);
    }
}
