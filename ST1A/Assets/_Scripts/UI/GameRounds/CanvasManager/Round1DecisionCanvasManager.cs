using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Manages the activation of decision and satisfaction canvases in round 1 after the speech bubble buttons above three NPCs have been clicked.
/// </summary>
public class Round1DecisionCanvasManager : MonoBehaviour
{
    [Header("NPC Speech Bubble Buttons")]
    // The buttons to be monitored
    [Tooltip("Speech bubble button above NPC 1")]
    public Button npcSpeechBubbleButton1;
    [Tooltip("Speech bubble button above NPC 2")]
    public Button npcSpeechBubbleButton2;
    [Tooltip("Speech bubble button above NPC 3")]
    public Button npcSpeechBubbleButton3;

    [Header("Decision Canvas to be activated after a delay")]
    // The decision canvas to be activated after a delay
    [Tooltip("The decision canvas to be activated after a delay")]
    public Canvas decisionCanvas;

    [Header("Satisfaction Canvas to be activated after a delay")]
    // The satisfaction canvas to be activated after a delay
    [Tooltip("The satisfaction canvas to be activated after a delay")]
    public Canvas satisfactionCanvas;

    [Header("Activation Settings")]
    // Delay before activating the canvases (in seconds)
    [Tooltip("Delay in seconds before the canvases are activated")]
    public float activationDelay = 5.0f;

    // Flags to monitor button clicks
    private bool button1Clicked = false;
    private bool button2Clicked = false;
    private bool button3Clicked = false;

    /// <summary>
    /// Initializes the buttons and sets up the click event listeners.
    /// </summary>
    private void Start()
    {
        // Add listeners for the buttons
        npcSpeechBubbleButton1.onClick.AddListener(() => OnButtonClick(1));
        npcSpeechBubbleButton2.onClick.AddListener(() => OnButtonClick(2));
        npcSpeechBubbleButton3.onClick.AddListener(() => OnButtonClick(3));

        // Ensure the canvases are deactivated at the start
        decisionCanvas.gameObject.SetActive(false);
        satisfactionCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// Method called when a button is clicked.
    /// </summary>
    /// <param name="buttonNumber">The number of the clicked button.</param>
    private void OnButtonClick(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1:
                if (!button1Clicked)
                {
                    button1Clicked = true;
                    CheckAllButtonsClicked();
                }
                break;
            case 2:
                if (!button2Clicked)
                {
                    button2Clicked = true;
                    CheckAllButtonsClicked();
                }
                break;
            case 3:
                if (!button3Clicked)
                {
                    button3Clicked = true;
                    CheckAllButtonsClicked();
                }
                break;
        }
    }

    /// <summary>
    /// Checks if all three buttons have been clicked and starts the coroutine if true.
    /// </summary>
    private void CheckAllButtonsClicked()
    {
        if (button1Clicked && button2Clicked && button3Clicked)
        {
            StartCoroutine(ActivateCanvasesAfterDelay(activationDelay));
        }
    }

    /// <summary>
    /// Coroutine to activate the canvases after a delay.
    /// </summary>
    /// <param name="delay">The delay in seconds.</param>
    private IEnumerator ActivateCanvasesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        decisionCanvas.gameObject.SetActive(true);
        satisfactionCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// Disables all NPC speech bubble buttons.
    /// </summary>
    public void DisableNpcSpeechBubbleButtons()
    {
        npcSpeechBubbleButton1.gameObject.SetActive(false);
        npcSpeechBubbleButton2.gameObject.SetActive(false);
        npcSpeechBubbleButton3.gameObject.SetActive(false);
    }
}
