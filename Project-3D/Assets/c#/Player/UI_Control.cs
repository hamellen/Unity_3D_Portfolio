using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{

    private PlayerController playercontroller;

    // Start is called before the first frame update
    void Start()
    {
        playercontroller = FindObjectOfType<PlayerController>();
    }

    public void Normal_Attack()
    {
        playercontroller.Normal_Attack();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
