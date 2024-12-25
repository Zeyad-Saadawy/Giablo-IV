using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneFragCollection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (PlayerHealthXP)
        PlayerHealthXP Player = other.GetComponent<PlayerHealthXP>();
        if (Player != null)
        {
            PlayerHealthXP.runeFragments++;
            // Destroy the runefragment after it's collected
            Destroy(gameObject);
        }

    }
}
