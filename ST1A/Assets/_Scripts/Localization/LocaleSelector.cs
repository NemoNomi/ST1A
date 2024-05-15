using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

/// <summary>
/// The LocaleSelector class handles changing the game's locale based on user input.
/// It saves the selected locale to PlayerPrefs and ensures only one locale change operation is active at a time.
/// </summary>

public class LocaleSelector : MonoBehaviour
{
    private void Start()
    {
        // Get the saved locale ID from PlayerPrefs, default to 0 if not found
        int ID = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLocale(ID); // Change to the saved locale
    }

    private bool active = false; // Flag to prevent multiple simultaneous locale changes

    // Public method to change the locale
    public void ChangeLocale(int localeID)
    {
        if (active)
            return; // If a locale change is already active, do nothing

        StartCoroutine(SetLocale(localeID)); // Start the coroutine to change the locale
    }

    // Coroutine to set the locale
    IEnumerator SetLocale(int _localeID)
    {
        active = true; // Set the active flag to true to indicate a locale change is in progress

        // Wait for the localization settings to be initialized
        yield return LocalizationSettings.InitializationOperation;

        // Set the selected locale to the locale with the specified ID
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];

        // Save the selected locale ID to PlayerPrefs
        PlayerPrefs.SetInt("LocaleKey", _localeID);

        active = false; // Reset the active flag to false to indicate the locale change is complete
    }
}
