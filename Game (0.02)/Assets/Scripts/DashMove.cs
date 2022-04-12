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
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
      dashTime = startDashTime;
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
          if(Input.GetButtonDown("Dash") && dashDirection == 1){
              direction = 1;
          } else if(Input.GetButtonDown("Dash") && dashDirection == -1){
              direction = 2;
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
    }
}
