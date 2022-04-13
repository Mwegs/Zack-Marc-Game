using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public Rigidbody2D bulletRB;
    
    void Start()
    {
      bulletRB.velocity = transform.right * bulletSpeed;
    }

    
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
       Destroy(gameObject); 
    }
}
