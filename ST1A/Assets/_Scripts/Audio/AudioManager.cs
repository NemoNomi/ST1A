using UnityEngine;

/// <summary>
/// The AudioManager class handles playing background music, sound effects, and UI sounds.
/// It uses the Singleton pattern to ensure only one instance of AudioManager exists throughout the game.
/// </summary>
public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource; // Audio source for background music
    [SerializeField] AudioSource SFXSource; // Audio source for sound effects
    [SerializeField] AudioSource UISource; // Audio source for UI sounds
    [SerializeField] private VolumeSettings volumeSettings; // Volume settings for managing audio levels

    [Header("Audio Clip")]
    public AudioClip background; // Background music clip
    public AudioClip SettingsMenuOpen; // Clip for opening settings menu
    public AudioClip SettingsMenuClose; // Clip for closing settings menu
    public AudioClip UISelect; // Clip for UI select sound
    public AudioClip UISubmit; // Clip for UI submit sound

    #region Singleton
    public static AudioManager instance; // Singleton instance

    private void Awake()
    {
        // Implementing Singleton pattern to ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this; // Set the instance to this object
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
    #endregion

    private void Start()
    {
        musicSource.clip = background; // Set the background music clip
        musicSource.Play(); // Play the background music
    }

    // Method to play a sound effect
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip); // Play the sound effect once
    }

    // Method to play a UI sound
    public void PlayUI(AudioClip clip)
    {
        UISource.PlayOneShot(clip); // Play the UI sound once
    }

    // Method to play the open menu sound
    public void PlayOpenMenuSound()
    {
        PlayUI(SettingsMenuOpen);
    }

    // Method to play the close menu sound
    public void PlayCloseMenuSound()
    {
        PlayUI(SettingsMenuClose);
    }
}
