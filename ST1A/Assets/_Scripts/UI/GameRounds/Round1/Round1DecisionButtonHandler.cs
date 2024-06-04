using UnityEngine;
using UnityEngine.UI;

public class Round1DecisionButtonHandler : MonoBehaviour
{
    [Tooltip("Buttons to proceed to round 2")]
    public Button[] decisionButtons; // Array of decision buttons

    [Tooltip("Round 1 Decision Canvas Manager")]
    public Round1DecisionPanelManager round1DecisionPanelManager;

    private void Start()
    {
        // Add listener to each decision button
        foreach (Button decisionButton in decisionButtons)
        {
            decisionButton.onClick.AddListener(() => OnDecisionButtonClicked(decisionButton));
        }
    }

    private void OnDecisionButtonClicked(Button decisionButton)
    {
        // Disable the corresponding NPC speech bubble button
        round1DecisionPanelManager.DisableNpcSpeechBubbleButton(decisionButton);

        // Proceed to next round or handle decision
        // Implement the logic for the next round here
    }
}
