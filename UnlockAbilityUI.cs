using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UnlockAbilityUI : MonoBehaviour
{
    // UI Texts for displaying ability status
    public TextMeshProUGUI ability1StatusText;
    public TextMeshProUGUI ability2StatusText;
    public TextMeshProUGUI ability3StatusText;

    // Buttons for unlocking abilities
    public Button ability1Button;
    public Button ability2Button;
    public Button ability3Button;

    // Cooldowns
    public TextMeshProUGUI ability1cd;
    public TextMeshProUGUI ability2cd;
    public TextMeshProUGUI ability3cd;

    void Start()
    {
        UpdateHUD();
    }

    void Update()
    {
        // Continuously update HUD to reflect the current state of abilities and cooldowns
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        // Fetch the cooldowns dynamically based on the selected character
        float ability1Cooldown = 0f;
        float ability2Cooldown = 0f;
        float ability3Cooldown = 0f;

        switch (PlayerHealthXP.characterSelected)
        {
            case 1: // Sorcerer
                SorcererController sorcerer = FindObjectOfType<SorcererController>();
                if (sorcerer != null)
                {
                    ability1Cooldown = sorcerer.teleportCooldownTimer;
                    ability2Cooldown = sorcerer.cloneCooldownTimer;
                    ability3Cooldown = sorcerer.infernoCooldownTimer;
                }
                break;

            case 2: // Rogue
                RogueController rogue = FindObjectOfType<RogueController>();
                if (rogue != null)
                {
                    ability1Cooldown = rogue.smokeDuration;
                    ability2Cooldown = rogue.dashCooldownTimer;
                    ability3Cooldown = rogue.arrowShowerCooldownTimer;
                }
                break;

            case 3: // Barbarian
                BarbarianScript barbarian = FindObjectOfType<BarbarianScript>();
                if (barbarian != null)
                {
                    ability1Cooldown = barbarian.cooldownDurations["ActivateShield"];
                    ability2Cooldown = barbarian.cooldownDurations["IronMaelstrom"];
                    ability3Cooldown = barbarian.cooldownDurations["EnterUltimateMode"];
                }
                break;

            default:
                Debug.LogWarning("No character selected.");
                break;
        }

        // Update the cooldown text for abilities
        UpdateAbilityCooldownUI(PlayerHealthXP.ability1Unlocked, ability1cd, ability1Cooldown, ability1StatusText, "Defensive");
        UpdateAbilityCooldownUI(PlayerHealthXP.ability2Unlocked, ability2cd, ability2Cooldown, ability2StatusText, "Wild Card");
        UpdateAbilityCooldownUI(PlayerHealthXP.ability3Unlocked, ability3cd, ability3Cooldown, ability3StatusText, "Ultimate");
    }

    private void UpdateAbilityCooldownUI(bool abilityUnlocked, TextMeshProUGUI cooldownText, float cooldown, TextMeshProUGUI statusText, string abilityName)
    {
        if (abilityUnlocked)
        {
            statusText.text = $"{abilityName}: Unlocked";
            cooldownText.text = cooldown > 0 ? $"{cooldown:F1}s" : "Ready";
        }
        else
        {
            statusText.text = $"{abilityName}: Locked";
            cooldownText.text = "Locked";
        }
    }

    public void UnlockAbility1()
    {
        if (!PlayerHealthXP.ability1Unlocked && PlayerHealthXP.abilityPoints > 0)
        {
            PlayerHealthXP.abilityPoints--;
            PlayerHealthXP.ability1Unlocked = true;
            Debug.Log("Ability 1 unlocked!");
        }

        UpdateHUD();
    }

    public void UnlockAbility2()
    {
        if (!PlayerHealthXP.ability2Unlocked && PlayerHealthXP.abilityPoints > 0)
        {
            PlayerHealthXP.abilityPoints--;
            PlayerHealthXP.ability2Unlocked = true;
            Debug.Log("Ability 2 unlocked!");
        }

        UpdateHUD();
    }

    public void UnlockAbility3()
    {
        if (!PlayerHealthXP.ability3Unlocked && PlayerHealthXP.abilityPoints > 0)
        {
            PlayerHealthXP.abilityPoints--;
            PlayerHealthXP.ability3Unlocked = true;
            Debug.Log("Ability 3 unlocked!");
        }

        UpdateHUD();
    }
}
