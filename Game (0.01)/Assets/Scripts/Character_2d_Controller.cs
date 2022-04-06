using UnityEngine;

public class Character_2d_Controller : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    public float DashForce;
    public float StartDashTimer;

    private float CurrentDashTimer;
    private int DashDirection;
    

    private bool isDashing;
    

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    //Allows player to move horizonally
    {
        print(DashDirection);
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;

    //Allows player to jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse); 
        }

        if (Input.GetButtonDown("Left"))
        {
            DashDirection = -1;
        } else if (Input.GetButtonDown("Right"))
        {
            DashDirection = 1;
        }

        if(Input.GetButtonDown("Dash"))
        {
            isDashing = true;
            CurrentDashTimer = StartDashTimer;
            rb.velocity = Vector2.zero;

        }

        if(isDashing)
        {
           rb.velocity = transform.right * DashDirection *DashForce;

            CurrentDashTimer -= Time.deltaTime;

            if(CurrentDashTimer <= 0)
            {
                isDashing = false;
            }           
        }
    }
}
