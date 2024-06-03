using UnityEngine;
using UnityEngine.UI;

public class Round1DecisionButtonHandler : MonoBehaviour
{
    // Disables the NPC speech bubbles when any of the Decision Buttons is clicked in round 1
    [Tooltip("Buttons to proceed to round 2")]
    public Button[] decisionButtons; // Array of decision buttons

    [Tooltip("Round 1 Decision Canvas Manager")]
    public Round1DecisionCanvasManager round1DecisionCanvasManager;

    private void Start()
    {
        // Add listener to each decision button
        foreach (Button decisionButton in decisionButtons)
        {
            decisionButton.onClick.AddListener(OnDecisionButtonClicked);
        }
    }

    private void OnDecisionButtonClicked()
    {
        // Disable the NPC speech bubble buttons
        round1DecisionCanvasManager.DisableNpcSpeechBubbleButtons();
    }
}
