using UnityEngine;
using TMPro;  // Ensure you have this namespace for TextMeshPro

public class HealingPortionsUI : MonoBehaviour
{
    // Reference to the UI TextMeshProUGUI component
    public TextMeshProUGUI healingPortionsText;

    void Start()
    {
        // Update the UI when the game starts
        UpdateHealingPortionsUI();
    }

    void Update()
    {
        // Continuously update the UI as needed (e.g., if portion count changes in your game)
        UpdateHealingPortionsUI();
    }

    // Method to update the UI Text element
    void UpdateHealingPortionsUI()
    {
        // Check if the healingPortionsText is assigned, then update
        if (healingPortionsText != null)
        {
            healingPortionsText.text = "Healing Portions: " + PlayerHealthXP.portionCount.ToString();
        }
    }

}
