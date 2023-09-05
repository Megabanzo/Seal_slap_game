using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    public float Force = 5.0f;
    private Rigidbody2D rb;

    private float y;
    private float x;

    public float minAngle1 = 30f;
    public float maxAngle1 = 60f;
    public float minAngle2 = 120f;
    public float maxAngle2 = 150f;

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
        rb.velocity = new Vector2(0, 0);

        float randomAngle = Random.Range(minAngle1, maxAngle1);
        if(Random.Range(0, 2) == 1)
        {
            randomAngle = Random.Range(minAngle1, maxAngle1);
        }
        float radians = Mathf.Deg2Rad * randomAngle;
        Vector2 randomDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

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
