using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGateScript : MonoBehaviour
{
    public GameObject openedgate;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (PlayerHealthXP)
        PlayerHealthXP player = other.GetComponent<PlayerHealthXP>();
        if (player != null)
        {
            if (PlayerHealthXP.runeFragments == 3)
            {
                // Open the gate
                if (openedgate != null)
                {
                    openedgate.SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                {
                    Debug.LogWarning("Opened gate object is not assigned in the Inspector.");
                }
            }
            else
            {
                Debug.Log("Not enough rune fragments to open the gate.");
            }
        }
    }
}
