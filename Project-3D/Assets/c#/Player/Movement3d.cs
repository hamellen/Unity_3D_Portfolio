using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement3d : MonoBehaviour
{

    

    private Vector2 moveDirection;

    public float movespeed = 5.0f;
    
    public void OnMovement(InputValue value)
    {

        moveDirection = value.Get<Vector2>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movevector = new Vector3(moveDirection.x, 0, moveDirection.y);

        

        transform.Translate(movespeed * Time.deltaTime * movevector);

    }
}
