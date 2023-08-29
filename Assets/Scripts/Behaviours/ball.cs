using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    public float Force = 5.0f;
    private Rigidbody2D rb;

    private float y;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ApplyRandomForce();
    }

    private void ApplyRandomForce()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 force = randomDirection * Force;
        rb.AddForce(force, ForceMode2D.Impulse);
        x = rb.velocity.x;
        y = rb.velocity.y;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("TopWall") || collision.gameObject.CompareTag("BottomWall"))
        {
            Debug.Log("here");
            y = -y;
            rb.velocity = new Vector2(rb.velocity.x, y);

        }
    }

}
