using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInputExample : MonoBehaviour
{
    public float MoveSpeed = 0.5f;
    public KeyCode UpKey = KeyCode.UpArrow;
    public KeyCode DownKey = KeyCode.DownArrow;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        rb.velocity = velocity;
    }
}
