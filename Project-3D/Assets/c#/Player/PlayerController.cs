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
    }

    private void OnEnable()
    {
        
    }

    public void Skill_Attack() {


        Debug.Log("ÄÞº¸ °ø°Ý");
        animator.SetTrigger("Skill");

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
