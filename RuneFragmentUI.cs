using UnityEngine;
using TMPro;  // Ensure you have this namespace for TextMeshPro

public class RuneFragmentUI : MonoBehaviour
{
    // Reference to the UI TextMeshProUGUI component
    public TextMeshProUGUI RuneFragText;


    void Start()
    {
        UpdateRuneText();
    }

    void Update()
    {
        UpdateRuneText();
    }

    void UpdateRuneText()
    {
        if (RuneFragText != null)
        {
            RuneFragText.text = "Rune Fragments: " + PlayerHealthXP.runeFragments.ToString();
        }
    }
}
