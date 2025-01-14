using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster_Controller : MonoBehaviour
{

    public delegate void Attack_Event(Define.Monster_State state);
    public event Attack_Event attack;

    public List<Reward> reward_list = new List<Reward>();

    public int random_range_move;
   
    public Transform central_point;
    Animator animator;
    NavMeshAgent agent;

    Weapon weapon;


    [SerializeField] Transform HpBar;
    [SerializeField] Camera camera;
    [SerializeField] Slider slider;

    [SerializeField] float view_angle = 0f;
    [SerializeField] float view_distance = 0f;
    [SerializeField] float attack_distance = 0f;
    [SerializeField] LayerMask view_layermask = 0;

    public bool IsChased;
    
    public MONSTER_STAT monster_stat;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
      
        camera = Camera.main;

        //player_stat = FindObjectOfType<PlayerController>().player_stat;
        //player_stat = Manager.DATAMANAGER.player_stat;
       
       
        slider = GetComponentInChildren<Slider>();

        monster_stat = GetComponent<MONSTER_STAT>();
        agent.speed = monster_stat.SPEED;
        weapon = GetComponentInChildren<Weapon>();
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

            transform.LookAt(other.gameObject.transform.position);
            Debug.Log("피격당함");
            monster_stat.HP = Mathf.Clamp(monster_stat.HP- Manager.DATAMANAGER.player_stat.ATTACK, 0, monster_stat.MAXHP);//문제 있음 
            slider.value = (monster_stat.HP / monster_stat.MAXHP);
            if (monster_stat.HP == 0) {
                //animator.SetBool("IsDead", true);
                FindObjectOfType<PlayerController>().ApplyEvent(Define.Player_type.GOLD, monster_stat.reward_gold);
                
                Generate_reward();
                Destroy(gameObject, 1.0f);
            }
        }
    }

    public void Attack() {

        animator.SetTrigger("Monster_Attack");
        attack(Define.Monster_State.ATTACK);
        agent.isStopped=true;
        
    }

    public void Generate_reward() {

        var resource= FindObjectOfType<Resource>();

        foreach (Reward reward in reward_list) {

            Reward_control control = reward.lootbox.GetComponent<Reward_control>();
           
            if (reward.type == Define.ItemType.Consumable)
            {
                Reward_con reward_con = reward as Reward_con;
                control.reward_base = reward_con;
                control.text_GUI.text = Manager.ITEMMANAGER.consumer_dic[reward_con.id].name;
                

                resource.Instantiate(reward.lootbox, transform);

                
            }
            else if (reward.type == Define.ItemType.Equipment) {//장비 

                Reward_equ reward_equ = reward as Reward_equ;
                control.reward_base = reward_equ;
                control.text_GUI.text = reward_equ.name;

                resource.Instantiate(reward.lootbox, transform);
            }
        
        }
    
    }
    public void Active_weapon() {

        weapon.Active_weapon();
    
    }

    public void DeActive_weapon() {

        weapon.DeActive_weapon();
    
    }
   

    // Update is called once per frame
    void Update()
    {
        Quaternion q_hp = Quaternion.LookRotation(HpBar.transform.position- camera.transform.position);
        Vector3 hp_angle = Quaternion.RotateTowards(HpBar.transform.rotation, q_hp, 100).eulerAngles;
        HpBar.rotation = Quaternion.Euler(0, hp_angle.y, 0);

        //-----------------------------------------------------

        Sight();

        
    }

    public void Patrol() {

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            
            Vector3 point;

            if (RandomPoint(central_point.position, random_range_move, out point))
            {
                Debug.Log("랜덤 위치 탐색 성공");
                agent.SetDestination(point);
                animator.SetFloat("Speed",5);
            }
            else
            {
                Debug.Log("랜덤 위치 탐색 실패");
                animator.SetFloat("Speed", 5);
                
            }
        }


    }

    bool RandomPoint(Vector3 center,float range,out Vector3 result) {

        Vector3 randomPoint = central_point.position + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, 5.0f, NavMesh.GetAreaFromName("walkable"))) {
           
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
        
    
    }

    void Sight()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, view_distance, view_layermask);

        
        if (cols.Length == 0)//순환움직임 
        {
            //Debug.Log("순찰중");
            Patrol();
            IsChased = false;
            animator.SetBool("IsChased", false);

        }

        if (cols.Length > 0)//플레이어 탐지 
        {
            Debug.Log("플레이어 탐지중");
            
            Transform spotted_player = cols[0].transform;

            Vector3 spotted_direction = (spotted_player.position - transform.position).normalized;
            float spotted_angle = Vector3.Angle(spotted_direction, transform.forward);

            if (spotted_angle < view_angle * 0.5f)
            {
                if (Physics.Raycast(transform.position, spotted_direction, out RaycastHit hit, view_distance))
                {
                    if (hit.transform.gameObject.tag == "Player")//추적시작
                    {
                        
                        IsChased = true;
                        animator.SetFloat("Speed",5);
                        animator.SetBool("IsChased", true);
                        
                        agent.SetDestination(hit.transform.position);

                        if (Vector3.Distance(transform.position, hit.transform.position) <= attack_distance) {
                            //Attack();
                        }

                        //navMeshAgent.SetDestination(hit.transform.position);
                    }
                }
                
            }
            else
            {
                Patrol();
            }
        }
    }
}
