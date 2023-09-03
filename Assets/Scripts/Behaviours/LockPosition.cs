using UnityEngine;

public class LockPosition : MonoBehaviour
{
    // This variable will allow you to adjust the locked X position.
    public float lockedXPosition = 0.0f;
    private void Start()
    {
        lockedXPosition = transform.position.x;
    }
    void Update()
    {
        // Lock the rotation
        transform.rotation = Quaternion.identity;

        // Lock the X position to the specified value
        Vector3 newPosition = transform.position;
        newPosition.x = lockedXPosition;
        transform.position = newPosition;
    }
}
