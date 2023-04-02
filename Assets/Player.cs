using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float jumpSpeed = 5;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (onGround && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            Jump();
        }
    }

    public void Jump()
    {
        print("jump");
        var jumpHeight = SpeedFromHeight(jumpSpeed);
        rb.velocity = Vector2.up * jumpHeight;
    }


    public bool onGround;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        onGround = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        onGround = false;
    }
    
    
    float SpeedFromHeight(float height)
    {
        return Mathf.Sqrt(-2 * Physics2D.gravity.y * rb.gravityScale * height);
    }
}
