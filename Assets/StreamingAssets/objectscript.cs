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

        // Register the callbacks for each image target to check for their status
        foreach (var target in imageTargets)
        {
            target.RegisterOnTrackableStatusChanged(OnTrackableStateChanged);
        }
    }

    private void OnTrackableStateChanged(TrackableBehaviour.StatusChangeResult statusChangeResult)
    {
        // Check if any of the targets are tracked
        foreach (var target in imageTargets)
        {
            if (target.CurrentStatus == TrackableBehaviour.Status.TRACKED ||
                target.CurrentStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
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
