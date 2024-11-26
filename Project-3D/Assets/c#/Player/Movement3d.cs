using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement3d : MonoBehaviour
{


    private CharacterController characterController;
    private PlayerInput playerinput;
    
    private Vector2 moveDirection2d;
    public Transform CameraBoom_Transform;
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
        characterController = GetComponent<CharacterController>();
    }

    public void ActiveMovement(InputAction.CallbackContext value)
    {

        moveDirection2d = value.ReadValue<Vector2>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camera_foward = CameraBoom_Transform.forward;
        Vector3 camera_right = CameraBoom_Transform.right;
        Vector3 movevector = camera_right * moveDirection2d.x + camera_foward * moveDirection2d.y;
        characterController.SimpleMove(movespeed * movevector);

    }
}
