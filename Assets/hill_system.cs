using UnityEngine;

public class HillInteraction : MonoBehaviour
{
    public GameObject shrine; 
    public GameObject bush; 
    public GameObject grass;
    public GameObject hill;

    private enum State
    {
        Hidden,
        Bushy, // When the bush is tapped
        Stuck, // When the grass is tapped
        Clean // When the hill is revealed
    }

    private State currentState = State.Hidden;

    void Start()
    {
        // Initially hide the hill with hole, chest, axe, and lid
        shrine.SetActive(true);
        bush.SetActive(true);
        grass.SetActive(true);
        hill.SetActive(true);
    }

    void Update()
    {
        // Check if the user has touched the screen
        if (Input.touchCount > 0)
        {
            HandleTap();
        }
        
    }

    private void HandleTap()
    {
        switch (currentState)
        {
            case State.Hidden:
                // Switch to the grassy and show the shrine
                bush.SetActive(false);
                currentState = State.Bushy;
                break;
            case State.Bushy:
                // Hide the grass to reveal more
                grass.SetActive(false);
                currentState = State.Stuck;
                break;
            case State.Stuck:
                //dig the hill
                hill.SetActive(false);
                currentState = State.Clean;
                break;
            case State.Clean:
                //reset
                bush.SetActive(true);
                grass.SetActive(true);
                hill.SetActive(true);
                currentState = State.Hidden;
                break;
        }
    }
}
