using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public CharacterSelectionHandler characterSelectionHandler; // Reference to the Character Selection Handler

    void LateUpdate()
    {
        // Dynamically get the active player from CharacterSelectionHandler
        GameObject activePlayer = characterSelectionHandler.GetActivePlayer();
        if (activePlayer != null)
        {
            Transform playerTransform = activePlayer.transform;
            Vector3 newPosition = playerTransform.position;
            newPosition.y = transform.position.y; // Keep the minimap's y position constant
            transform.position = newPosition; // Update the minimap's position to follow the player
            transform.rotation = Quaternion.Euler(90f, playerTransform.eulerAngles.y, 0f); // Rotate the minimap to match the player's orientation
        }
    }
}
