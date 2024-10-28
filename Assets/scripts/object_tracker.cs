using UnityEngine;
using Vuforia;

public class MultiTargetTracker : MonoBehaviour
{
    public GameObject virtualObject; // The virtual object you want to show/hide
    public ImageTargetBehaviour[] imageTargets; // Array to store the 4 image targets

    private void Start()
    {
        // Ensure the virtual object is initially hidden
        virtualObject.SetActive(false);

        // Subscribe to the status changes for each target
        foreach (var target in imageTargets)
        {
            target.OnTargetStatusChanged += OnTrackableStateChanged;
        }
    }

    private void OnTrackableStateChanged(ObserverBehaviour target, TargetStatus targetStatus)
    {
        // Check if any of the targets are tracked
        foreach (var t in imageTargets)
        {
            if (t.TargetStatus.Status == Status.TRACKED || t.TargetStatus.Status == Status.EXTENDED_TRACKED)
            {
                // If any of the targets are being tracked, enable the virtual object
                virtualObject.SetActive(true);
                return; // Exit early if at least one target is tracked
            }
        }

        // If no targets are tracked, hide the virtual object
        virtualObject.SetActive(false);
    }
}
