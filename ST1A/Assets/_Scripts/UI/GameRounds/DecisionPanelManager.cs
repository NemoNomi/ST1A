using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Manages the activation of a decision panel after at least one of the decision buttons has been clicked.
/// </summary>
public class DecisionPanelManager : MonoBehaviour
{
    [Header("Decision Buttons from the round before")]
    // The buttons to be monitored
    [Tooltip("First decision button")]
    public Button decisionButton1;
    [Tooltip("Second decision button")]
    public Button decisionButton2;
    [Tooltip("Third decision button")]
    public Button decisionButton3;

    [Header("Decision Panel to be activated after a delay")]
    // The panel to be activated after a delay
    [Tooltip("The panel to be activated after a delay")]
    public GameObject decisionPanel;

    [Header("Activation Settings")]
    // Delay before activating the decision panel (in seconds)
    [Tooltip("Delay in seconds before the decision panel is activated")]
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

        // Ensure the decision panel is deactivated at the start
        decisionPanel.SetActive(false);
    }

    /// <summary>
    /// Method called when any button is clicked.
    /// </summary>
    private void OnButtonClick()
    {
        if (!anyButtonClicked)
        {
            anyButtonClicked = true;
            StartCoroutine(ActivateDecisionPanelAfterDelay(activationDelay));
        }
    }

    /// <summary>
    /// Coroutine to activate the decision panel after a delay.
    /// </summary>
    /// <param name="delay">The delay in seconds.</param>
    private IEnumerator ActivateDecisionPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        decisionPanel.SetActive(true);
    }
}
