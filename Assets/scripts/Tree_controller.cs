using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public GameObject[] trees;  // Array to hold your tree types (3 normal trees and 3 snowy versions)
    private int currentTreeIndex = 0;
    private bool isSnowy = false;  // To track if the snow version is active

    void Start()
    {
        // Make sure only the first tree is active at the start
        UpdateTree();
    }

    // Call this method when the "Change Tree" button is clicked
    public void ChangeTree()
    {
        // Cycle through only the base trees (non-snowy versions)
        currentTreeIndex = (currentTreeIndex + 1) % 3;  // There are 3 normal trees
        UpdateTree();
    }

    // Call this method when the "Snow On/Off" button is clicked
    public void ToggleSnow()
    {
        isSnowy = !isSnowy;  // Toggle the snowy state
        UpdateTree();
    }

    private void UpdateTree()
    {
        // First, disable all trees
        for (int i = 0; i < trees.Length; i++)
        {
            trees[i].SetActive(false);
        }

        // Then, activate the correct tree based on the currentTreeIndex and isSnowy state
        int treeToActivate = currentTreeIndex * 2;  // Each tree type has 2 versions: normal and snowy
        if (isSnowy)
        {
            treeToActivate += 1;  // Switch to the snowy version if snowy is active
        }

        trees[treeToActivate].SetActive(true);
    }
}
