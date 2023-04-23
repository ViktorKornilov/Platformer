using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float side = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(side, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyWall"))
        {
            side = -side;
        }
    }
}
