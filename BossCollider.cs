using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    public GameObject OpenedGate;
    public GameObject ClosedGate;
    public GameObject minimap;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (PlayerHealthXP)
        PlayerHealthXP player = other.GetComponent<PlayerHealthXP>();
        if (player != null)
        {
            // close the gate
            if (ClosedGate != null && OpenedGate !=null)
            {
                ClosedGate.SetActive(true);
                OpenedGate.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Closed/opened gate object is not assigned in the Inspector.");
            }

            // close the minimap
            if (minimap != null)
            {
                minimap.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Minimap object is not assigned in the Inspector.");
            }
            Destroy(gameObject);
        }
    }
}
