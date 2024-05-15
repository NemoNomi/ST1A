using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// The VolumeSettings class handles the audio volume settings for music, sound effects, UI, and master volume.
/// It allows setting and saving these values using sliders and PlayerPrefs.
/// </summary>
/// 
public class VolumeSettings : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private AudioMixer myMixer; // Reference to the AudioMixer
    [SerializeField] private Slider musicSlider; // Slider for music volume
    [SerializeField] private Slider SFXSlider; // Slider for sound effects volume
    [SerializeField] private Slider masterSlider; // Slider for master volume
    [SerializeField] private Slider UISlider; // Slider for UI volume
    #endregion

    #region Set Default Values
    private void Start()
    {
        SetDefaultVolumeValues(); // Set default volume values on start
    }
    #endregion

    #region Setting Audio Volumes
    // Sets the music volume based on the slider value
    public void SetMusicVolume()
    {
        float volume = musicSlider.value; // Get the value from the music slider
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20); // Set the music volume in the mixer
        PlayerPrefs.SetFloat("musicVolume", volume); // Save the value in PlayerPrefs
    }

    // Sets the sound effects (SFX) volume based on the slider value
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value; // Get the value from the SFX slider
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20); // Set the SFX volume in the mixer
        PlayerPrefs.SetFloat("SFXVolume", volume); // Save the value in PlayerPrefs
    }

    // Sets the UI volume based on the slider value
    public void SetUIVolume()
    {
        float volume = UISlider.value; // Get the value from the UI slider
        myMixer.SetFloat("UI", Mathf.Log10(volume) * 20); // Set the UI volume in the mixer
        PlayerPrefs.SetFloat("UIVolume", volume); // Save the value in PlayerPrefs
    }

    // Sets the master volume based on the slider value
    public void SetMasterVolume()
    {
        float volume = masterSlider.value; // Get the value from the master slider
        myMixer.SetFloat("master", Mathf.Log10(volume) * 20); // Set the master volume in the mixer
        PlayerPrefs.SetFloat("masterVolume", volume); // Save the value in PlayerPrefs
    }
    #endregion

    #region Loading PlayerPrefs Volumes
    // Loads the volume settings from PlayerPrefs
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume"); // Load music volume
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume"); // Load SFX volume
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume"); // Load master volume
        UISlider.value = PlayerPrefs.GetFloat("UIVolume"); // Load UI volume
        SetMusicVolume(); // Apply the loaded music volume
        SetSFXVolume(); // Apply the loaded SFX volume
        SetMasterVolume(); // Apply the loaded master volume
        SetUIVolume(); // Apply the loaded UI volume
    }
    #endregion

    #region Loading Default Volumes
    // Sets default volume values if they are not already set
    private void SetDefaultVolumeValues()
    {
        // Check if music volume is not set, then set a default value
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.75f); // Default music volume
        }
        // Check if SFX volume is not set, then set a default value
        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 0.75f); // Default SFX volume
        }
        // Check if master volume is not set, then set a default value
        if (!PlayerPrefs.HasKey("masterVolume"))
        {
            PlayerPrefs.SetFloat("masterVolume", 0.75f); // Default master volume
        }
        // Check if UI volume is not set, then set a default value
        if (!PlayerPrefs.HasKey("UIVolume"))
        {
            PlayerPrefs.SetFloat("UIVolume", 0.75f); // Default UI volume
        }

        LoadVolume(); // Load the volume settings
    }
    #endregion
}
