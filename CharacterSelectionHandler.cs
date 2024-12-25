using UnityEngine;
using Cinemachine;

public class CharacterSelectionHandler : MonoBehaviour
{
    public GameObject sorcerer;  // Reference to the Sorcerer GameObject
    public GameObject rogue;     // Reference to the Rogue GameObject
    public GameObject barbarian; // Reference to the Barbarian GameObject
    public CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine Virtual Camera
    public int characterSelected; // The character selected by the player



    void Start()
    {
        // Deactivate all characters initially
        sorcerer.SetActive(false);
        rogue.SetActive(false);
        barbarian.SetActive(false);
        characterSelected = MenuHandler.selectedCharacter;


        // Activate the chosen character and set the camera
        switch (characterSelected)
        {
            case 1: // Sorcerer
                sorcerer.SetActive(true);
                virtualCamera.Follow = sorcerer.transform;
                virtualCamera.LookAt = sorcerer.transform;
                break;

            case 2: // Rogue
                rogue.SetActive(true);
                virtualCamera.Follow = rogue.transform;
                virtualCamera.LookAt = rogue.transform;
                break;

            case 3: // Barbarian
                barbarian.SetActive(true);
                virtualCamera.Follow = barbarian.transform;
                virtualCamera.LookAt = barbarian.transform;
                break;

            default:
                Debug.LogWarning("No character selected! Ensure MenuHandler.selectedCharacter is set correctly.");
                break;
        }
    }


    public GameObject GetActivePlayer()
    {
        if (sorcerer.activeSelf) return sorcerer;
        if (rogue.activeSelf) return rogue;
        if (barbarian.activeSelf) return barbarian;
        return null;  // Return null if no character is active
    }

}
