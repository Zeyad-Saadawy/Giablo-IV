using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthXP : MonoBehaviour
{
    public static int currhealth;
    public static int characterSelected = MenuHandler.selectedCharacter;
    public static int portionCount;
    public static int level;
    public static int xp;
    public static int maxHealth;
    public static int abilityPoints;
    public static int maxXP;
    public static int runeFragments;

    

    // Abilities
    public static bool ability1Unlocked = false;
    public static bool ability2Unlocked = false;
    public static bool ability3Unlocked = false;

    // XP threshold calculation for leveling up
    private int XPRequiredForLevelUp => 100 * level;


    void Start()
    {
        currhealth = 100;
        portionCount = 0;
        maxHealth = 100;
        level = 1;
        xp = 0;
        abilityPoints = 0;
        maxXP = XPRequiredForLevelUp;
        runeFragments = 0;
    }

    void Update()
    {
        HandleKeyboardInput();
        HandleLevelingUp();
        CheckIfDead();
    }

    private void HandleKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
            usePotion();
        else if (Input.GetKeyDown(KeyCode.W) && ability1Unlocked)
            ActivateAbility(1); // Defensive
        else if (Input.GetKeyDown(KeyCode.Q) && ability2Unlocked)
            ActivateAbility(2); // Wild card
        else if (Input.GetKeyDown(KeyCode.E) && ability3Unlocked)
            ActivateAbility(3); // Ultimate

        // Cheats
        else if (Input.GetKeyDown(KeyCode.H))
            cheat_Heal(20); // Heal by 20 points
        else if (Input.GetKeyDown(KeyCode.D))
            cheat_DecrementHealth(20); // Decrease health by 20 points
        else if (Input.GetKeyDown(KeyCode.U))
            cheat_UnlockAllAbilities(); // Unlock all abilities
        else if (Input.GetKeyDown(KeyCode.A))
            cheat_GainAbilityPoint(); // Gain 1 ability point
        else if (Input.GetKeyDown(KeyCode.X))
            cheat_GainXP(100); // Gain 100 XP
    }

    void CheckIfDead()
    {
        if (currhealth <= 0)
        {
            Debug.Log("Player is dead!");
        }
    }



    private void usePotion()
    {
        if (portionCount > 0 && currhealth < maxHealth)
        {
            // Heal by 50% of curr health or up to the maximum health
            int healAmount = Mathf.FloorToInt(currhealth * 0.5f);
            currhealth = Mathf.Min(currhealth + healAmount, maxHealth);

            portionCount--; // Decrease potion count
            Debug.Log($"Healed! Current health: {currhealth}, Potions left: {portionCount}");
            // animation 
            // Check the selected character and call the appropriate method
            if (characterSelected == 1)
            {
                // Get the SorcererController component from the collided player and call PickupPotion()
                SorcererController sorcerer = this.GetComponent<SorcererController>();
                if (sorcerer != null)
                {
                    sorcerer.DrinkPotion();  // Call the method to handle potion pickup
                    print("Potion sound done");
                }
            }
            else if (characterSelected == 2)
            {
                // Get the RogueController component from the collided player and call PickupPotion()
                RogueController rogue = this.GetComponent<RogueController>();
                if (rogue != null)
                {
                    rogue.DrinkPotion();  // Call the method to handle potion pickup
                }
            }
            else if (characterSelected == 3)
            {
                // Get the BarbarianScript component from the collided player and call PickupPotion()
                BarbarianScript barbarian = this.GetComponent<BarbarianScript>();
                if (barbarian != null)
                {
                    barbarian.DrinkPotion();  // Call the method to handle potion pickup
                }
            }
        }
    }

    private void ActivateAbility(int abilityNumber)
    {
        switch (characterSelected)
        {
            case 1: // Sorcerer
                var sorcerer = GetComponent<SorcererController>();
                if (sorcerer != null)
                {
                    if (abilityNumber == 1)
                    {
                        SorcererController.ability1activated = true;
                        sorcerer.HandleTeleportInput();
                    }
                    else if (abilityNumber == 2)
                    {
                        SorcererController.ability2activated = true;
                        sorcerer.HandleCloneInput();
                    }
                    else if (abilityNumber == 3)
                    {
                        SorcererController.ability3activated = true;
                        sorcerer.HandleInfernoInput();
                    }
                }
                break;

            case 2: // Rogue
                var rogue = GetComponent<RogueController>();
                if (rogue != null)
                {
                    if (abilityNumber == 1)
                    {
                        RogueController.ability1activated = true;
                        rogue.HandleSmokeBombInput();
                    }
                    else if (abilityNumber == 2)
                    {
                        RogueController.ability2activated = true;
                        rogue.HandleDashInput();
                    }
                    else if (abilityNumber == 3)
                    {
                        RogueController.ability3activated = true;
                        rogue.HandleShowerOfArrowsInput();
                    }
                }
                break;

            case 3: // Barbarian
                var barbarian = GetComponent<BarbarianScript>();
                if (barbarian != null)
                {
                    if (abilityNumber == 1)
                    {
                        BarbarianScript.ability1activated = true;
                        barbarian.HandleKeyBoardInput();
                    }
                    else if (abilityNumber == 2)
                    {
                        BarbarianScript.ability2activated = true;
                        barbarian.HandleKeyBoardInput();
                    }
                    else if (abilityNumber == 3)
                    {
                        BarbarianScript.ability3activated = true;
                        barbarian.HandleKeyBoardInput();
                    }
                }
                break;
        }
    }



    private void HandleLevelingUp()
    {
        if (xp >= maxXP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        // If the level is already 4, do nothing (max level)
        if (level >= 4)
        {
            Debug.Log("Max level reached!");
            return;
        }

        // Level up
        level++;
        abilityPoints++; // Grant ability point on level up
        maxHealth += 100; // Increase max health by 100
        currhealth = maxHealth; // Refill HP to max
        maxXP = 100 * level; // Update max XP needed for next level
        xp = Mathf.Max(0, maxXP - xp); // Overflow XP after leveling up (for example 150 XP will give 50 XP after leveling up)

        Debug.Log($"Leveled up to level {level}! Max Health: {maxHealth}, Ability Points: {abilityPoints}, XP overflow: {xp}");
    }

    // This method will be called when the player kills an enemy and gains XP
    public static void GainXP(int amount)
    {
        if (level >= 4)
        {
            Debug.Log("Max level reached! No more XP gains.");
            return;
        }

        xp += amount;

        if (xp >= maxXP)
        {
            Debug.Log("Level up triggered!");
        }
    }

   

    ////////////////////////////////////////////////////    CHEATS      //////////////////////////
    
    // Method to increase health
    private void cheat_Heal(int amount)
    {
        currhealth = Mathf.Min(currhealth + amount, maxHealth);
        Debug.Log($"Healed! Current health: {currhealth}");
    }

    // Method to decrease health
    private void cheat_DecrementHealth(int amount)
    {
        currhealth = Mathf.Max(currhealth - amount, 0);
        Debug.Log($"Health decreased! Current health: {currhealth}");
    }

    // Method to unlock all abilities
    private void cheat_UnlockAllAbilities()
    {
        if (!ability1Unlocked) ability1Unlocked = true;
        if (!ability2Unlocked) ability2Unlocked = true;
        if (!ability3Unlocked) ability3Unlocked = true;

        Debug.Log("All abilities unlocked!");
    }

    // Method to gain 1 ability point
    private void cheat_GainAbilityPoint()
    {
        abilityPoints++;
        Debug.Log($"Ability points increased! Current ability points: {abilityPoints}");
    }

    // Method to gain XP
    private void cheat_GainXP(int amount)
    {
        GainXP(amount);
        Debug.Log($"XP gained! Current XP: {xp}");
    }
}
