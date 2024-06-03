using UnityEngine;
using UnityEngine.UI;

public class PanelToggleManager : MonoBehaviour
{
    // The panel to be activated/deactivated
    public GameObject targetPanel;

    // The button to toggle the panel
    private Button button;

    /// <summary>
    /// Initializes the button and sets up the click event listener.
    /// </summary>
    private void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        // If no Button component is found, log an error and exit
        if (button == null)
        {
            Debug.LogError("No Button component found on this GameObject.");
            return;
        }

        // Add the OnButtonClick method as a listener for the button's click event
        button.onClick.AddListener(OnButtonClick);
    }

    /// <summary>
    /// Activates the target panel when the button is clicked.
    /// </summary>
    private void OnButtonClick()
    {
        // Check if the target panel is assigned
        if (targetPanel != null)
        {
            // Activate the target panel
            targetPanel.SetActive(true);
        }
        else
        {
            // Log an error if the target panel is not assigned
            Debug.LogError("Target Panel is not assigned.");
        }
    }

    /// <summary>
    /// Toggles the active state of the target panel.
    /// </summary>
    public void TogglePanel()
    {
        // Check if the target panel is assigned
        if (targetPanel != null)
        {
            // Toggle the active state of the target panel
            bool isActive = targetPanel.activeSelf;
            targetPanel.SetActive(!isActive);
        }
        else
        {
            // Log an error if the target panel is not assigned
            Debug.LogError("Target Panel is not assigned.");
        }
    }
}
