using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpSpeed = 5;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var hit = Physics2D.Raycast(transform.position,Vector2.down,1f,groundLayer);
        onGround = hit.transform != null;
        
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

        if (onGround && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            Jump();
        }

        
        if (rb.velocity.x != 0)
        {
            spriteRenderer.flipX = rb.velocity.x < 0;
        }


    }

    public void Jump()
    {
        var jumpHeight = SpeedFromHeight(jumpSpeed);
        rb.velocity = Vector2.up * jumpHeight;
    }


    public bool onGround;
    
    
    float SpeedFromHeight(float height)
    {
        return Mathf.Sqrt(-2 * Physics2D.gravity.y * rb.gravityScale * height);
    }
}
