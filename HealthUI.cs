using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;  // Reference to the TextMeshPro UI element

    void Start()
    {
        // Initialize the health text at the start
        healthText.gameObject.SetActive(true);
        UpdateHealthText();
    }

    void Update()
    {
        // Check the current health from the PlayerHealthXP script and update the health UI text
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        // Ensure we are referencing the correct script to get the current health value
        healthText.text = "Health: " + PlayerHealthXP.currhealth.ToString();
    }
}
