using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private int dashDirection;
    public bool isDashing;
    public float noGrav;
    public float normGrav;
    public float dashCooldown = 2;
    private float nextDashTime = 0;
    
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
      dashTime = startDashTime;
      isDashing = false;
    }

    
    void Update()
    {
      if(Input.GetButtonDown("Right")){
          dashDirection= 1;
      }
      if(Input.GetButtonDown("Left")){
          dashDirection= -1;
      }
      if(direction ==0)
      {
          if(Input.GetButtonDown("Dash") && dashDirection == 1 && Time.time > nextDashTime){
              direction = 1;
              isDashing = true;
              rb.gravityScale = noGrav;
              nextDashTime = Time.time + dashCooldown;
              
          } else if(Input.GetButtonDown("Dash") && dashDirection == -1 && Time.time > nextDashTime){
              direction = 2;
              isDashing = true;
              rb.gravityScale = noGrav;
              nextDashTime = Time.time + dashCooldown;
          }
      } else {
          if(dashTime <= 0 && !Input.GetButtonDown("Right")){
              direction = 0;
              dashTime = startDashTime;
              rb.velocity = Vector2.zero;
          } else {
              dashTime -= Time.deltaTime;

              if(direction == 1){
                  rb.velocity = Vector2.right * dashSpeed;
              } else if(direction == 2){
                  rb.velocity = Vector2.left * dashSpeed;
              }
          }
      }
      if (dashTime <= 0){
           isDashing = false;
           rb.gravityScale = normGrav;
      } 
    }
}
