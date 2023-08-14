using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode UpKey = KeyCode.UpArrow; // Keycode for up
    public KeyCode DownKey = KeyCode.DownArrow; // Keycode for up
    public float MoveSpeed = 5.0f; // The force to apply for the jump

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        bool up = Input.GetKey(UpKey);
        bool down = Input.GetKey(DownKey);
        // Check if the jump key is pressed
        if (up || down)
        {
            // Apply the jump force to the character's y velocity
            Vector2 velocity = rb.velocity;

            if (up && !down)
            {
                velocity.y = MoveSpeed;
            }else if(down && !up)
            {
                velocity.y = -MoveSpeed;
            }
   

            rb.velocity = velocity;
        }

        // Check if the jump key is pressed
        //if (Input.GetKey(DownKey))
        //{
        //    // Apply the jump force to the character's y velocity
        //    Vector2 velocity = rb.velocity;
        //    velocity.y = -MoveSpeed;
        //    rb.velocity = velocity;
        //}
    }
}