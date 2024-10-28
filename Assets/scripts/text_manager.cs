using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Find the main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Make the text face the camera
        transform.LookAt(mainCamera.transform);
        // Optional: Invert the rotation for a better orientation
        transform.Rotate(0, 180, 0);
    }
}
