using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// The SettingsMenuManager handles the display and interaction with the settings menu,
/// including pausing and resuming the game, and managing the visibility of different settings canvases.
/// It also handles playing audio feedback when menus are opened or closed.
/// </summary>
public class SettingsMenuManager : MonoBehaviour
{
    #region Serialized Fields
    [Header("Pause Menu Canvas")]
    [SerializeField] private GameObject CanvasSettingsMenuGO; // Main settings canvas
    [SerializeField] private GameObject CanvasAudioSettingsGO; // Audio settings canvas
    [SerializeField] private GameObject CanvasLanguageSettingsGO; // Language settings canvas

    [Header("UI Elements")]
    [SerializeField] private Image settingsButtonImage; // Image for the settings (gear) icon
    #endregion

    #region Private Fields
    private bool isPaused = false; // Indicates if the game is paused
    private AudioManager audioManager; // Reference to the AudioManager
    #endregion

    #region Unity Lifecycle
    private void Start()
    {
        InitializeMenus(); // Initialize the menus

        // Get the AudioManager instance
        audioManager = AudioManager.instance;

        // Debugging: Check if AudioManager instance is found
        if (audioManager == null)
        {
            Debug.LogError("AudioManager instance not found.");
        }
    }
    #endregion

    #region Initialization
    private void InitializeMenus()
    {
        SetMenuVisibility(false); // Set all menus to be invisible initially
    }
    #endregion

    #region Game Pause/Resume/Restart
    public void TogglePauseResume()
    {
        if (isPaused)
        {
            ResumeGame(); // Resume the game if it is currently paused
        }
        else
        {
            PauseGame(); // Pause the game if it is currently running
        }
    }

    private void PauseGame()
    {
        isPaused = true; // Set the game status to paused
        Time.timeScale = 0f; // Pause the game
        OpenSettingsMenu(); // Open the main settings menu

        // Play the open menu sound using AudioManager
        if (audioManager != null)
        {
            audioManager.PlayOpenMenuSound();
        }
    }

    public void ResumeGame()
    {
        isPaused = false; // Set the game status to not paused
        Time.timeScale = 1f; // Resume the game
        CloseAllMenus(); // Close all menus

        // Play the close menu sound using AudioManager
        if (audioManager != null)
        {
            audioManager.PlayCloseMenuSound();
        }
    }

    public void RestartScene()
    {
        // Get the currently active scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGamePaused()
    {
        return isPaused; // Return whether the game is paused
    }
    #endregion

    #region Menu Visibility
    private void SetMenuVisibility(bool isVisible)
    {
        // Set the visibility of the different menus
        CanvasSettingsMenuGO.SetActive(isVisible);
        CanvasAudioSettingsGO.SetActive(isVisible);
        CanvasLanguageSettingsGO.SetActive(isVisible);
    }

    private void OpenSettingsMenu()
    {
        SetMenuVisibility(false); // Close all menus
        CanvasSettingsMenuGO.SetActive(true); // Open the main settings menu
    }

    private void OpenAudioSettings()
    {
        SetMenuVisibility(false); // Close all menus
        CanvasAudioSettingsGO.SetActive(true); // Open the audio settings menu
    }

    private void OpenLanguageSettings()
    {
        SetMenuVisibility(false); // Close all menus
        CanvasLanguageSettingsGO.SetActive(true); // Open the language settings menu
    }

    private void CloseAllMenus()
    {
        SetMenuVisibility(false); // Close all menus
    }
    #endregion

    #region UI Button Handlers
    public void OnAudioSettingsPress()
    {
        OpenAudioSettings(); // Handle audio settings button press
    }

    public void OnLanguageSettingsPress()
    {
        OpenLanguageSettings(); // Handle language settings button press
    }

    public void OnResumePress()
    {
        ResumeGame(); // Handle resume button press
    }

    public void OnRestartPress()
    {
        RestartScene(); // Handle restart button press
    }

    public void OnAudioSettingsBackPress()
    {
        OpenSettingsMenu(); // Handle back button press in audio settings
    }

    public void OnLanguageSettingsBackPress()
    {
        OpenSettingsMenu(); // Handle back button press in language settings
    }
    #endregion
}
