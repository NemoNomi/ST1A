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

    [Header("Panels to Deactivate After Continue Button Click")]
    public GameObject[] panelsToDeactivateAfterContinueButtonClick;

    [Header("Panels to Activate in Sequence")]
    public GameObject[] panelsToActivateInSequence; // Array of panels to activate in sequence
    public float[] activationDelays; // Array of activation delays for each panel

    [Header("Additional Elements to Deactivate")]
    public GameObject[] additionalElementsToDeactivate;

    [Header("Activation Settings")]
    public float startDiscussionButtonDelay = 5.0f; // Delay before the start discussion button appears
    public float satisfactionCanvasActivationDelay = 2.0f; // Delay before the satisfaction canvas appears
    public float understoodButtonActivationDelay = 1.5f; // Delay before the understood button appears

    [Header("New Button for Starting Discussion")]
    public Button startDiscussionButton; // Add a new button

    [Header("New Button for Understood")]
    public Button understoodButton; // Add a new button

    [Header("Satisfaction Canvas")]
    public GameObject satisfactionCanvas; // Drag and drop the Satisfaction Canvas GameObject here
    public GameObject satisfactionPanelChild; // Drag and drop the child panel of Satisfaction Canvas GameObject here

    private bool[] buttonClicked = new bool[3];

    private void Start()
    {
        npcSpeechBubbleButton1.onClick.AddListener(() => OnButtonClick(0));
        npcSpeechBubbleButton2.onClick.AddListener(() => OnButtonClick(1));
        npcSpeechBubbleButton3.onClick.AddListener(() => OnButtonClick(2));

        startDiscussionButton.gameObject.SetActive(false); // Hide the new button initially
        understoodButton.gameObject.SetActive(false); // Hide the new button initially

        startDiscussionButton.onClick.AddListener(OnStartDiscussionButtonClicked);
        understoodButton.onClick.AddListener(OnUnderstoodButtonClicked);
    }

    private void OnButtonClick(int buttonIndex)
    {
        buttonClicked[buttonIndex] = true;
        CheckAllButtonsClicked();
    }

    private void CheckAllButtonsClicked()
    {
        foreach (bool clicked in buttonClicked)
        {
            if (!clicked)
                return;
        }

        StartCoroutine(ActivatePanelsAfterDelay(startDiscussionButtonDelay));
    }

    private IEnumerator ActivatePanelsAfterDelay(float delay)
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
        foreach (GameObject panel in panelsToDeactivateAfterContinueButtonClick)
        {
            panel.SetActive(false);
        }

        StartCoroutine(ActivateSatisfactionCanvasAfterDelay(satisfactionCanvasActivationDelay));
    }

    private IEnumerator ActivateSatisfactionCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Activate the satisfaction canvas
        satisfactionCanvas.SetActive(true);

        // Activate the understood button after a delay
        StartCoroutine(ActivateUnderstoodButtonAfterDelay(understoodButtonActivationDelay));
    }

    private IEnumerator ActivateUnderstoodButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Activate the understood button
        understoodButton.gameObject.SetActive(true);
    }

    private void OnUnderstoodButtonClicked()
    {
        // Deactivate the satisfaction panel child
        satisfactionPanelChild.SetActive(false);
         understoodButton.gameObject.SetActive(false);

        // Activate panels in sequence
        StartCoroutine(ActivatePanelsInSequence());
    }

    private IEnumerator ActivatePanelsInSequence()
    {
        for (int i = 0; i < panelsToActivateInSequence.Length; i++)
        {
            yield return new WaitForSeconds(activationDelays[i]);

            panelsToActivateInSequence[i].SetActive(true);
        }

        // Deactivate additional elements
        foreach (GameObject element in additionalElementsToDeactivate)
        {
            element.SetActive(false);
        }

        // Optionally, deactivate the start discussion button
        startDiscussionButton.gameObject.SetActive(false);
    }

    public void DisableNpcSpeechBubbleButton(Button button)
    {
        button.gameObject.SetActive(false);
    }
}
