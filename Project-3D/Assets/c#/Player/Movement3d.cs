using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Movement3d : MonoBehaviour
{



    private PlayerInput playerinput;
    public Rigidbody rb;
    private Vector2 moveDirection2d;

    public Transform cam;
    public float movespeed = 5.0f;
    private Animator animator;


    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private void Awake()
    {
        playerinput = new PlayerInput();


        playerinput.Player.Movement.started += ActiveMovement;
        playerinput.Player.Movement.performed += ActiveMovement;
        playerinput.Player.Movement.canceled += ActiveMovementEnd;



    }
    private void OnEnable()
    {
        playerinput.Player.Movement.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        cam = Camera.main.transform;

        movespeed = GetComponent<PLAYER_STAT>().Speed;
    }

    public void ActiveMovementEnd(InputAction.CallbackContext value) {

        moveDirection2d = new Vector2(0, 0);
    } 

    public void ActiveMovement(InputAction.CallbackContext value)
    {

        moveDirection2d = value.ReadValue<Vector2>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 camera_foward = new Vector3(0,0, LookAt.position.z - CameraBoom_Transform.position.z);
        // camera_foward.Normalize();
        // Vector3 camera_right = new Vector3(right.position.x - LookAt.position.x, 0,0);
        // camera_right.Normalize();

        //Vector3 movevector = camera_right * moveDirection2d.x + camera_foward * moveDirection2d.y;

        //rb.MovePosition(rb.position + movevector * movespeed * Time.deltaTime);//rigidbody 객체는 사실상 해당 함수 사용
        //transform.Translate(movevector * Time.deltaTime*movespeed, Space.World);//물리작용이 필요없는 오브젝트에서 사용


        //moveDirection2d = new Vector2(0, 0);
        Vector3 direction = new Vector3(moveDirection2d.x, 0f, moveDirection2d.y).normalized;

        if (direction.magnitude >= 0.1f)
        {

            animator.SetBool("IsRunning", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(rb.position + moveDir.normalized * movespeed * Time.deltaTime);
        }
        else {
           
            animator.SetBool("IsRunning", false);
        }
    }
}
