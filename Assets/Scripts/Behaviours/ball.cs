using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    public float Force = 5.0f;
    private Rigidbody2D rb;

    private float y;
    private float x;

    private Vector2 initPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ApplyRandomForce();

        initPos = transform.position;
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

        if (collision.gameObject.CompareTag("TopWall"))
        {

            if (y > 0)
            {
                y = -y;
            }
            rb.velocity = new Vector2(x, y);

        }else if (collision.gameObject.CompareTag("BottomWall"))
        {
            if (y < 0)
            {
                y = -y;
            }
            rb.velocity = new Vector2(x, y);

        }
        else if (collision.gameObject.CompareTag("RightWall"))
        {
        
            GameController.IncrementCatPoints(1);
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("LeftWall"))
        {

            GameController.IncrementSealPoints(1);
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("Seal"))
        {
            if(x > 0)
            {
                x = -x;
                rb.velocity = new Vector2(x, y);
            }
        }
        else if (collision.gameObject.CompareTag("Cat"))
        {
            if(x < 0)
            {
                x = -x;
                rb.velocity = new Vector2(x, y);
            }
        }


    }

    private void ResetBall()
    {
        transform.position = initPos;
        ApplyRandomForce();
    }


}
