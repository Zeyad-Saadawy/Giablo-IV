using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitCollision : MonoBehaviour
{
    public static int characterSelected = MenuHandler.selectedCharacter;
    // Remove the direct references to the scripts, as you'll access them dynamically
    // public SorcererController sorcererScript;
    // public RogueController rogueScript;
    // public BarbarianScript barbarianScript;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (PlayerHealthXP)
        PlayerHealthXP playerHealth = other.GetComponent<PlayerHealthXP>();
        if (playerHealth != null)
        {
            // Increment portion count if it's less than the maximum (3)
            if (PlayerHealthXP.portionCount < 3)
            {
                PlayerHealthXP.portionCount++;
                Debug.Log($"Potion collected! Current potion count: {PlayerHealthXP.portionCount}");

                // Check the selected character and call the appropriate method
                if (characterSelected == 1)
                {
                    // Get the SorcererController component from the collided player and call PickupPotion()
                    SorcererController sorcerer = other.GetComponent<SorcererController>();
                    if (sorcerer != null)
                    {
                        sorcerer.PickupPotion();  // Call the method to handle potion pickup
                        print("Potion sound done");
                    }
                }
                else if (characterSelected == 2)
                {
                    // Get the RogueController component from the collided player and call PickupPotion()
                    RogueController rogue = other.GetComponent<RogueController>();
                    if (rogue != null)
                    {
                        rogue.PickupPotion();  // Call the method to handle potion pickup
                    }
                }
                else if (characterSelected == 3)
                {
                    // Get the BarbarianScript component from the collided player and call PickupPotion()
                    BarbarianScript barbarian = other.GetComponent<BarbarianScript>();
                    if (barbarian != null)
                    {
                        barbarian.PickupPotion();  // Call the method to handle potion pickup
                    }
                }

                // Destroy the medkit after it's collected
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Potion count is already at the maximum (3).");
            }
        }
    }
}
