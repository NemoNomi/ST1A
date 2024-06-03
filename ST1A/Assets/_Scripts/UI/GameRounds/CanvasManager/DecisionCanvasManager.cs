using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Manages the activation of a decision canvas after at least one of the decision buttons has been clicked.
/// </summary>
public class DecisionCanvasManager : MonoBehaviour
{
    [Header("Decision Buttons from the round before")]
    // The buttons to be monitored
    [Tooltip("First decision button")]
    public Button decisionButton1;
    [Tooltip("Second decision button")]
    public Button decisionButton2;
    [Tooltip("Third decision button")]
    public Button decisionButton3;

    [Header("Decision Canvas to be activated after a delay")]
    // The canvas to be activated after a delay
    [Tooltip("The canvas to be activated after a delay")]
    public Canvas decisionCanvas;

    [Header("Activation Settings")]
    // Delay before activating the decision canvas (in seconds)
    [Tooltip("Delay in seconds before the decision canvas is activated")]
    public float activationDelay = 5.0f;

    // Flag to monitor if any button has been clicked
    private bool anyButtonClicked = false;

    /// <summary>
    /// Initializes the buttons and sets up the click event listeners.
    /// </summary>
    private void Start()
    {
        // Add listeners for the buttons
        decisionButton1.onClick.AddListener(() => OnButtonClick());
        decisionButton2.onClick.AddListener(() => OnButtonClick());
        decisionButton3.onClick.AddListener(() => OnButtonClick());

        // Ensure the decision canvas is deactivated at the start
        decisionCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// Method called when any button is clicked.
    /// </summary>
    private void OnButtonClick()
    {
        if (!anyButtonClicked)
        {
            anyButtonClicked = true;
            StartCoroutine(ActivateDecisionCanvasAfterDelay(activationDelay));
        }
    }

    /// <summary>
    /// Coroutine to activate the decision canvas after a delay.
    /// </summary>
    /// <param name="delay">The delay in seconds.</param>
    private IEnumerator ActivateDecisionCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        decisionCanvas.gameObject.SetActive(true);
    }
}
