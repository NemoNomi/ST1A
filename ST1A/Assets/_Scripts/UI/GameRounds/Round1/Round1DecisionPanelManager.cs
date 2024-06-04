using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Round1DecisionPanelManager : MonoBehaviour
{
    [Header("NPC Speech Bubble Buttons")]
    public Button npcSpeechBubbleButton1;
    public Button npcSpeechBubbleButton2;
    public Button npcSpeechBubbleButton3;

    [Header("Decision Panel to be activated after a delay")]
    public GameObject decisionPanel;

    [Header("Satisfaction Canvas to be activated after a delay")]
    public Canvas satisfactionCanvas;

    [Header("Additional Elements to Deactivate")]
    public GameObject[] additionalElementsToDeactivate;

    [Header("Activation Settings")]
    public float activationDelay = 5.0f;

    private bool button1Clicked = false;
    private bool button2Clicked = false;
    private bool button3Clicked = false;

    private void Start()
    {
        npcSpeechBubbleButton1.onClick.AddListener(() => OnButtonClick(1));
        npcSpeechBubbleButton2.onClick.AddListener(() => OnButtonClick(2));
        npcSpeechBubbleButton3.onClick.AddListener(() => OnButtonClick(3));

        decisionPanel.SetActive(false);
        satisfactionCanvas.gameObject.SetActive(false);
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
            StartCoroutine(ActivatePanelsAfterDelay(activationDelay));
        }
    }

    private IEnumerator ActivatePanelsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Activate decision panel and satisfaction canvas
        decisionPanel.SetActive(true);
        satisfactionCanvas.gameObject.SetActive(true);

        // Deactivate NPC speech bubble buttons
        npcSpeechBubbleButton1.gameObject.SetActive(false);
        npcSpeechBubbleButton2.gameObject.SetActive(false);
        npcSpeechBubbleButton3.gameObject.SetActive(false);

        // Deactivate additional elements
        foreach (GameObject element in additionalElementsToDeactivate)
        {
            element.SetActive(false);
        }
    }

    public void DisableNpcSpeechBubbleButtons()
    {
        npcSpeechBubbleButton1.gameObject.SetActive(false);
        npcSpeechBubbleButton2.gameObject.SetActive(false);
        npcSpeechBubbleButton3.gameObject.SetActive(false);
    }
}
