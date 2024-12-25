using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider musicSlider; // The slider for volume control
    //public Slider effectsSlider; // Slider for effects volume

    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip mainMenuAudio; // Audio for Main Menu
    public AudioClip gameplayAudio; // Audio for gameplay (Main and Boss scenes)

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
        PlayAudioForCurrentScene();
        DontDestroyOnLoad(gameObject);
        if (musicSlider != null)
        {
            musicSlider.value = audioSource.volume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }
        
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to prevent memory leaks
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayAudioForCurrentScene();
    }

    private void PlayAudioForCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "MainMenu")
        {
            audioSource.clip = mainMenuAudio;
        }
        else 
        {
            audioSource.clip = gameplayAudio;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
    
}
