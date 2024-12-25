using UnityEngine;
using TMPro;  // Ensure you have this namespace for TextMeshPro

public class AbilityPointsUI : MonoBehaviour
{
    // Reference to the UI TextMeshProUGUI component
    public TextMeshProUGUI AbilityPointsText;

    void Start()
    {
        // Update the UI when the game starts
        UpdateAbilityPointsUI();
    }

    void Update()
    {
        // Continuously update the UI as needed (e.g., if portion count changes in your game)
        UpdateAbilityPointsUI();
    }

    // Method to update the UI Text element
    void UpdateAbilityPointsUI()
    {
        // Check if the healingPortionsText is assigned, then update
        if (AbilityPointsText != null)
        {
            AbilityPointsText.text = "Ability Points: " + PlayerHealthXP.abilityPoints.ToString();
        }
    }

}
