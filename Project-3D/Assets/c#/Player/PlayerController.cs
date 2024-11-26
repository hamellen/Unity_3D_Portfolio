using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private PlayerInput playerinput;
    private Vector3 lookVector;
    private Vector2 moveDirection2d;
    public Transform CameraBoom_Transform;

    private void Awake()
    {
        playerinput = new PlayerInput();
        playerinput.Player.Enable();

        playerinput.Player.Movement.started += ActiveRotation;
        playerinput.Player.Movement.performed += ActiveRotation;
        playerinput.Player.Movement.canceled += ActiveRotation;
    }


    public void ActiveRotation(InputAction.CallbackContext value)
    {

        moveDirection2d = value.ReadValue<Vector2>();
        Vector3 camera_foward = CameraBoom_Transform.forward;
        Vector3 camera_right = CameraBoom_Transform.right;
        lookVector = camera_right * moveDirection2d.x + camera_foward * moveDirection2d.y;
        if (lookVector.magnitude != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVector), 0.5f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

    }
}
