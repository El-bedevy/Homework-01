using UnityEngine;

public class CharacterRollController : MonoBehaviour
{
    public Animator animator;  // Assign a single Animator with both animations
    public float rollSpeed = 5f; // Speed of rolling
    private bool isRollingForward = true; // Direction of rolling

    void Start()
    {
        // Start with the forward roll animation
        animator.SetTrigger("RollForward");
    }

    void Update()
    {
        // Move the character based on the current rolling direction
        if (isRollingForward)
        {
            transform.position += new Vector3(0, 0, rollSpeed * Time.deltaTime); // Increase Z-coordinate
        }
        else
        {
            transform.position += new Vector3(0, 0, -rollSpeed * Time.deltaTime); // Decrease Z-coordinate
        }
    }

    // Call this method to toggle the rolling direction
    public void ToggleRollDirection()
    {
        isRollingForward = !isRollingForward;

        if (isRollingForward)
        {
            animator.SetTrigger("RollForward"); // Play forward roll animation
        }
        else
        {
            animator.SetTrigger("RollBackward"); // Play backward roll animation
        }
    }
}
