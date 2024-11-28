using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement3d : MonoBehaviour
{


   
    private PlayerInput playerinput;
    private Rigidbody rb;
    private Vector2 moveDirection2d;
    public float movespeed = 5.0f;

    private void Awake()
    {
        playerinput = new PlayerInput();
        playerinput.Player.Enable();

        playerinput.Player.Movement.started += ActiveMovement;
        playerinput.Player.Movement.performed += ActiveMovement;
        playerinput.Player.Movement.canceled += ActiveMovement;

    }

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ActiveMovement(InputAction.CallbackContext value)
    {

        moveDirection2d = value.ReadValue<Vector2>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = moveDirection2d.x;
        float vertical= moveDirection2d.y;

        // Vector3 camera_foward = new Vector3(0,0, LookAt.position.z - CameraBoom_Transform.position.z);
        // camera_foward.Normalize();
        // Vector3 camera_right = new Vector3(right.position.x - LookAt.position.x, 0,0);
        // camera_right.Normalize();

        //Vector3 movevector = camera_right * moveDirection2d.x + camera_foward * moveDirection2d.y;

        //rb.MovePosition(rb.position + movevector * movespeed * Time.deltaTime);//rigidbody 객체는 사실상 해당 함수 사용
        //transform.Translate(movevector * Time.deltaTime*movespeed, Space.World);//물리작용이 필요없는 오브젝트에서 사용

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) {

            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            rb.MovePosition(rb.position + direction * movespeed * Time.deltaTime);
        }
    }
}
