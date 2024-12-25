using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    // References to the canvases
    public GameObject MainMenu;
    public GameObject OptionsCanvas; // Reference to the options panel canvas
    public GameObject NewGameLevel;
    public GameObject ChoosingPlayer;
    // Global variable to store the selected character type
    public static int selectedCharacter = 0;

    // Function to handle Sorcerer button click
    public void OnSorcererButtonClicked()
    {
        selectedCharacter = 1; // Assign 1 for Sorcerer
        startGame();
    }

    // Function to handle Rogue button click
    public void OnRogueButtonClicked()
    {
        selectedCharacter = 2; // Assign 2 for Rogue
        startGame();

    }

    // Function to handle Barbarian button click
    public void OnBarbarianButtonClicked()
    {
        selectedCharacter = 3; // Assign 3 for Barbarian
        startGame();


    }
    public void startGame()
    {
        SceneManager.LoadScene("NewGamePlay");

    }

    public void OnPlayButtonClicked()
    {
        // Set the MainMenu canvas to inactive
        MainMenu.SetActive(false);

        // Set the ChoosingPlayer canvas to active
        ChoosingPlayer.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void ShowOptionsMenu()
    {
        MainMenu.SetActive(false);
        OptionsCanvas.SetActive(true);
    }
    public void HideOptionsMenu()
    {
        OptionsCanvas.SetActive(false);
        MainMenu.SetActive(true);
    }


    public void HidePlayerMenu()
    {
        ChoosingPlayer.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void HideNewGameMenu()
    {
        NewGameLevel.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void ShowCharacterssss()
    {
        NewGameLevel.SetActive(false);
        ChoosingPlayer.SetActive(true);
    }

}
