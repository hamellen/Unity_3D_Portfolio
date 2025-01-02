using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Animator animator;

    private PlayerInput playerinput;
   
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerinput = new PlayerInput();
       
        //foot_sfx = Manager.RESOURCES.Load<AudioClip>("SFX/Footsteps - Essentials/Footsteps_Grass/Footsteps_Grass_Run/Footsteps_Grass_Run_11");
    }

    private void OnEnable()
    {
        
    }

    public void Skill_Attack() {


        Debug.Log("ÄÞº¸ °ø°Ý");
        animator.SetTrigger("Skill");

    }

    public void FootStep() {


        Manager.SOUNDMANAGER.Play_Position(transform.position, "SFX/Footsteps - Essentials/Footsteps_Grass/Footsteps_Grass_Run/Footsteps_Grass_Run_11",2.0f);
        Debug.Log("¶Ñ¹÷");
    
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

       

    }
}
