using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Controller : MonoBehaviour
{

    public List<IMAGE_ITEM> rewards = new List<IMAGE_ITEM>();

    Animator animator;
    NavMeshAgent agent;

    [SerializeField] Transform HpBar;
    [SerializeField] Camera camera;


    STAT monster_stat;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        monster_stat = GetComponent<STAT>();

        camera = Camera.main;
       

        monster_stat = GetComponent<STAT>();

        

        
        //if (Manager.DATAMANAGER.StatDict.TryGetValue(1,out stat)){

        //    monster_stat.HP = stat.hp;
        //    monster_stat.MAXHP= stat.maxhp;
        //    monster_stat.ATTACK = stat.attack;
        //    monster_stat.DEFENCE = stat.defence;
        //    monster_stat.SPEED = stat.speed;
        //}
    }

   
    // Update is called once per frame
    void Update()
    {
        Quaternion q_hp = Quaternion.LookRotation(HpBar.transform.position- camera.transform.position);
        Vector3 hp_angle = Quaternion.RotateTowards(HpBar.transform.rotation, q_hp, 100).eulerAngles;
        HpBar.rotation = Quaternion.Euler(0, hp_angle.y, 0);
    }
}
