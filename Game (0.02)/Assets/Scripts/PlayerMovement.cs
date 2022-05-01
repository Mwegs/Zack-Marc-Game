using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    DashMove dashMove;
    [SerializeField] GameObject player;

     void Awake()
    {
        dashMove = GameObject.Find("Player").GetComponent<DashMove>();
    }


    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

       if (Input.GetButtonDown("Jump"))
       {
            jump = true;
       }

       if (Input.GetButtonDown("Crouch"))
       {
            crouch = true;
       } else if (Input.GetButtonUp("Crouch"))
       {
           crouch = false;
       }
    }

    void FixedUpdate()
    {
        if (dashMove.isDashing == false)
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}

