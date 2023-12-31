using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInputExample : MonoBehaviour
{
    public float MoveSpeed = 0.5f;
    public float defaultStrength = 5f;
    public float WhackStrength = 15f;
    public int WhackDirection = 1;

    public KeyCode UpKey = KeyCode.UpArrow;
    public KeyCode DownKey = KeyCode.DownArrow;
    public KeyCode WhackKey = KeyCode.E;

    public Sprite[] sprites;

    public GameObject WhackZone;

    private Rigidbody2D rb;

    public LayerMask CheckLayer;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collidersInArea = Physics2D.OverlapBoxAll(WhackZone.transform.position, WhackZone.transform.localScale / 2, 0, CheckLayer);

        Vector2 velocity = rb.velocity;
        if (Input.GetKey(UpKey) && !Input.GetKey(DownKey))
        {
            // transform.position = transform.position + new Vector3(0, MoveSpeed, 0);
            velocity.y = MoveSpeed;
        }

        if (Input.GetKey(DownKey) && !Input.GetKey(UpKey))
        {
            // transform.position = transform.position + new Vector3(0, -MoveSpeed, 0);
            velocity.y = -MoveSpeed;

        }

        if (Input.GetKey(WhackKey))
        {
            sr.sprite = sprites[2];
            foreach (Collider2D col in collidersInArea)
            {
                Debug.Log(col.tag);
                if (col.CompareTag("Ball"))
                {
                    ball.InvertBallX(rb.velocity.y, WhackStrength * WhackDirection);
                    Debug.Log("whack");
                }
            }
        }

        else if (Input.GetKeyUp(WhackKey))
        {
            sr.sprite = sprites[1];
        }
        else
        {
            sr.sprite = sprites[0];
        }

        rb.velocity = velocity;
    }
}
