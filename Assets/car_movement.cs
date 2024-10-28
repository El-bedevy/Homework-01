using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Movement settings
    public float moveDistance = 5f;   // Distance the car moves forward
    public float speed = 2f;          // Speed of the car movement

    private Vector3 startPosition;    // Starting position of the car
    private bool movingForward = true; // Direction of the car

    void Start()
    {
        // Store the initial position of the car
        startPosition = transform.position;
    }

    void Update()
    {
        // Check if the car is moving forward or backward
        if (movingForward)
        {
            // Move the car forward
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // Check if it has reached the target distance
            if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
            {
                // Change direction to move back
                movingForward = false;
            }
        }
        else
        {
            // Move the car back
            transform.Translate(Vector3.back * speed * Time.deltaTime);

            // Check if it has returned to the start position
            if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
            {
                // Change direction to move forward again
                movingForward = true;
            }
        }
    }
}
