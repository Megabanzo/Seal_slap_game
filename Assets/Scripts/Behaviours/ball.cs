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

    private GameController gc;
    public static ball Instance;

    private Vector2 initPos;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ApplyRandomForce();

        initPos = transform.position;

        gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        
    }

    private void ApplyRandomForce()
    {
        rb.velocity = new Vector2(0, 0);

        float randomAngle = Random.Range(minAngle1, maxAngle1);
        if(Random.Range(0, 2) == 1)
        {
            randomAngle = Random.Range(minAngle2, maxAngle2);
        }

        float radians = Mathf.Deg2Rad * randomAngle;
        Vector2 randomDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

        Vector2 force = randomDirection * Force;

        if (Random.Range(0, 1) == 1)
        {
            force = -force;
        }


        rb.AddForce(force, ForceMode2D.Impulse);
        x = rb.velocity.x;
        y = rb.velocity.y;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RightWall"))
        {

            gc.IncrementCatPoints(1);
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("LeftWall"))
        {

            gc.IncrementSealPoints(1);
            ResetBall();
        }

        if (collision.gameObject.CompareTag("TopWall"))
        {

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(x, -rb.velocity.y);
                Debug.Log("top");
            }

        }
        else if (collision.gameObject.CompareTag("BottomWall"))
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(x, -rb.velocity.y);
                Debug.Log("bottom");

            }

        }
    }

    public static void InvertBallX(float yVel, float strength)
    {

        Instance.x = -Instance.x;
        Instance.rb.velocity = new Vector2(Instance.x + strength, yVel);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Seal"))
        {
            if(x > 0)
            {
                InvertBallX(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y, 0f);
            }
        }
        else if (collision.gameObject.CompareTag("Cat"))
        {
            if(x < 0)
            {
                InvertBallX(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y, 0f);


            }
        }


    }

    private void ResetBall()
    {
        transform.position = initPos;
        ApplyRandomForce();
    }


}
