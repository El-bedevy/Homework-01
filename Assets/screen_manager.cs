using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARModeSwitcher : MonoBehaviour
{
    // Public variables to assign in Unity Inspector
    public GameObject canvasImage; // The GameObject containing the raw Image
    public GameObject planeVideo;  // The GameObject containing the video player
    public GameObject quadDefault; // The default state GameObject
    public Button modeButton;      // Reference to the mode switch button

    private int modeIndex = 0; // 0 = Default, 1 = Image, 2 = Video

    void Start()
    {
        // Attach the button click event
        modeButton.onClick.AddListener(ToggleMode);

        // Initialize to default mode
        SetMode(0);
    }

    void ToggleMode()
    {
        modeIndex = (modeIndex + 1) % 3; // Cycle through modes 0, 1, and 2
        SetMode(modeIndex);
    }

    void SetMode(int mode)
    {
        // Disable only the specific GameObjects for each mode
        canvasImage.SetActive(false);
        planeVideo.SetActive(false);
        quadDefault.SetActive(false);

        // Enable only the GameObject for the current mode
        switch (mode)
        {
            case 0: // Default mode
                quadDefault.SetActive(true);
                break;
            case 1: // Image mode
                canvasImage.SetActive(true);
                break;
            case 2: // Video mode
                planeVideo.SetActive(true);
                break;
        }
    }
}
