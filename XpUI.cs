using UnityEngine;
using TMPro;  // For TextMeshPro support

public class XpUI : MonoBehaviour
{
    public TextMeshProUGUI xpText;  // Reference to the XP UI TextMeshPro

    void Start()
    {
        UpdateXPUI();
    }
    void Update()
    {
        UpdateXPUI();
    }

    // Updates the XP UI text
    void UpdateXPUI()
    {
        if (xpText != null)
        {
            xpText.text = "XP: " + PlayerHealthXP.xp.ToString();
        }
      
    }
}
