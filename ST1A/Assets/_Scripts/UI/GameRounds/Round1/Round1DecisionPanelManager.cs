using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Round1DecisionPanelManager : MonoBehaviour
{
    [Header("NPC Speech Bubble Buttons")]
    public Button npcSpeechBubbleButton1;
    public Button npcSpeechBubbleButton2;
    public Button npcSpeechBubbleButton3;

    [Header("Panels to Activate After All Bubbles Clicked")]
    public GameObject[] panelsToActivateAfterBubblesClicked;

    [Header("Panels to Deactivate After Button Click")]
    public GameObject[] panelsToDeactivateAfterButtonClick;

    [Header("Panels to Activate in Sequence")]
    public GameObject panelToActivateImmediately;
    public GameObject[] panelsToActivateAfterImmediate;
    public GameObject panelToActivateAfterSecondDelay;
    public GameObject satisfactionCanvasPanel;
    public GameObject decisionPanel;

    [Header("Task Panel to be activated after a delay")]
    public GameObject taskPanel;

    [Header("Additional Elements to Deactivate")]
    public GameObject[] additionalElementsToDeactivate;

    [Header("Activation Settings")]
    public float activationDelay = 5.0f;

    [Header("New Button for Starting Discussion")]
    public Button startDiscussionButton; // Add a new button

    private bool button1Clicked = false;
    private bool button2Clicked = false;
    private bool button3Clicked = false;

    private void Start()
    {
        npcSpeechBubbleButton1.onClick.AddListener(() => OnButtonClick(1));
        npcSpeechBubbleButton2.onClick.AddListener(() => OnButtonClick(2));
        npcSpeechBubbleButton3.onClick.AddListener(() => OnButtonClick(3));

        decisionPanel.SetActive(false);
        taskPanel.SetActive(false);
        satisfactionCanvasPanel.SetActive(false);
        startDiscussionButton.gameObject.SetActive(false); // Hide the new button initially

        startDiscussionButton.onClick.AddListener(OnStartDiscussionButtonClicked);
    }

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

    private void CheckAllButtonsClicked()
    {
        if (button1Clicked && button2Clicked && button3Clicked)
        {
            StartCoroutine(ActivatePanelsAndButtonAfterDelay(activationDelay));
        }
    }

    private IEnumerator ActivatePanelsAndButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (GameObject panel in panelsToActivateAfterBubblesClicked)
        {
            panel.SetActive(true);
        }

        startDiscussionButton.gameObject.SetActive(true); // Activate the new button
    }

    private void OnStartDiscussionButtonClicked()
    {
        // Deactivate the specified panels
        foreach (GameObject element in additionalElementsToDeactivate)
        {
            element.SetActive(false);
        }

        // Deactivate specified panels after button click
        foreach (GameObject panel in panelsToDeactivateAfterButtonClick)
        {
            panel.SetActive(false);
        }

        // Activate the panels in sequence
        StartCoroutine(ActivateDiscussionPanelsInSequence());
    }

    private IEnumerator ActivateDiscussionPanelsInSequence()
    {
        // Activate the panel immediately
        panelToActivateImmediately.SetActive(true);

        // Wait for the activation delay
        yield return new WaitForSeconds(activationDelay);

        //
        // Activate the next set of panels
        foreach (GameObject panel in panelsToActivateAfterImmediate)
        {
            panel.SetActive(true);
        }

        // Wait for the activation delay
        yield return new WaitForSeconds(activationDelay);

        // Activate the additional panel
        panelToActivateAfterSecondDelay.SetActive(true);

        // Wait for the activation delay
        yield return new WaitForSeconds(activationDelay);

        // Activate the satisfaction canvas and decision panel
        satisfactionCanvasPanel.SetActive(true);
        decisionPanel.SetActive(true);

        // Optionally, deactivate the start discussion button
        startDiscussionButton.gameObject.SetActive(false);
    }

    public void DisableNpcSpeechBubbleButtons()
    {
        npcSpeechBubbleButton1.gameObject.SetActive(false);
        npcSpeechBubbleButton2.gameObject.SetActive(false);
        npcSpeechBubbleButton3.gameObject.SetActive(false);
    }
}
