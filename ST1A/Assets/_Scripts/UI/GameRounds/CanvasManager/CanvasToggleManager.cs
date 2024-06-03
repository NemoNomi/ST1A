using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the activation and deactivation of a target canvas through button clicks.
/// </summary>
public class CanvasToggleManager : MonoBehaviour
{
    // The canvas to be activated/deactivated
    public Canvas targetCanvas;

    /// <summary>
    /// Initializes the button and sets up the click event listener.
    /// </summary>
    private void Start()
    {
        // Get the Button component attached to this GameObject
        Button button = GetComponent<Button>();

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
    /// Activates the target canvas when the button is clicked.
    /// </summary>
    private void OnButtonClick()
    {
        // Check if the target canvas is assigned
        if (targetCanvas != null)
        {
            // Activate the target canvas
            targetCanvas.gameObject.SetActive(true);
        }
        else
        {
            // Log an error if the target canvas is not assigned
            Debug.LogError("Target Canvas is not assigned.");
        }
    }

    /// <summary>
    /// Toggles the active state of the target canvas.
    /// </summary>
    public void ToggleCanvas()
    {
        // Check if the target canvas is assigned
        if (targetCanvas != null)
        {
            // Toggle the active state of the target canvas
            bool isActive = targetCanvas.gameObject.activeSelf;
            targetCanvas.gameObject.SetActive(!isActive);
        }
        else
        {
            // Log an error if the target canvas is not assigned
            Debug.LogError("Target Canvas is not assigned.");
        }
    }
}
