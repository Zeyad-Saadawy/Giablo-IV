using UnityEngine;
using TMPro;  // Ensure you have this namespace for TextMeshPro

public class LevelUI : MonoBehaviour
{
    // Reference to the UI TextMeshProUGUI component
    public TextMeshProUGUI levelText;


    void Start()
    {
        UpdateLevelUI();
    }

    void Update()
    {
        UpdateLevelUI();
    }

    void UpdateLevelUI()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + PlayerHealthXP.level.ToString();
        }
    }
}
