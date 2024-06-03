using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }

    [Header("Buttons")]
    public Button npcButton1;
    public Button npcButton2;
    public Button npcButton3;

    [Header("Panels")]
    public GameObject firstPanel;
    public GameObject secondPanel;

    [Header("Other Settings")]
    [Tooltip("The speech bubble button of the first NPC")]
    public Button firstNpcSpeechBubbleButton;

    [Tooltip("Arrow GameObject pointing to the first button")]
    public GameObject arrow;

    [Header("Color Settings")]
    [Tooltip("The color of the button when it is disabled")]
    public Color disabledColor = new Color(0.78f, 0.78f, 0.78f);

    private NPCMovementManager npcMovementManager;
    private bool firstNpcReached = false;
    private bool secondNpcReached = false;
    private bool thirdNpcReached = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        npcMovementManager = FindObjectOfType<NPCMovementManager>();
        if (npcMovementManager == null)
        {
            Debug.LogError("NPCMovementManager not found in the scene.");
            return;
        }

        SetButtonInteractable(npcButton1, false);
        SetButtonInteractable(npcButton2, false);
        SetButtonInteractable(npcButton3, false);

        arrow.SetActive(false);

        firstNpcSpeechBubbleButton.onClick.AddListener(OnFirstNpcSpeechBubbleClicked);

        // Initially deactivate the panels
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
    }

    private void SetButtonInteractable(Button button, bool isInteractable)
    {
        button.interactable = isInteractable;
        ColorBlock colors = button.colors;
        colors.disabledColor = disabledColor;
        button.colors = colors;
    }

    public void OnIntroCompleted()
    {
        SetButtonInteractable(npcButton1, true);
        arrow.SetActive(true);
        Debug.Log("Intro completed, first NPC button enabled.");
    }

    private void OnFirstNpcSpeechBubbleClicked()
    {
        SetButtonInteractable(npcButton2, true);
        SetButtonInteractable(npcButton3, true);

        arrow.SetActive(false);

        Debug.Log("First NPC's speech bubble clicked, other buttons enabled.");

        firstNpcSpeechBubbleButton.onClick.RemoveListener(OnFirstNpcSpeechBubbleClicked);

        // Deactivate the first panel and activate the second panel
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
    }

    public void OnNPCButtonClicked(int npcIndex)
    {
        Debug.Log($"NPC Button {npcIndex} clicked.");

        if (arrow.activeSelf)
        {
            arrow.SetActive(false);
        }

        if (npcMovementManager != null)
        {
            npcMovementManager.MoveNPC(npcIndex);
            Debug.Log($"NPC {npcIndex} should be moving.");

            Button clickedButton = null;
            switch (npcIndex)
            {
                case 0:
                    clickedButton = npcButton1;
                    break;
                case 1:
                    clickedButton = npcButton2;
                    break;
                case 2:
                    clickedButton = npcButton3;
                    break;
            }
            if (clickedButton != null)
            {
                Animator animator = clickedButton.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetBool("IsClicked", true);
                }

                StartCoroutine(DisableButtonAfterAnimation(clickedButton, 0.5f));

                if (npcIndex == 0 && !firstNpcReached)
                {
                    // Mark that the first NPC is being moved
                    firstNpcReached = true;
                }
            }
        }
        else
        {
            Debug.LogError("NPCMovementManager is not assigned.");
        }
    }

    public void OnNPCReachedTarget(int npcIndex)
    {
        switch (npcIndex)
        {
            case 0:
                firstNpcReached = true;
                firstPanel.SetActive(true);
                break;
            case 1:
                secondNpcReached = true;
                break;
            case 2:
                thirdNpcReached = true;
                break;
        }

        // Deactivate the second panel if both second and third NPCs have reached their targets
        if (secondNpcReached && thirdNpcReached)
        {
            secondPanel.SetActive(false);
        }
    }

    private IEnumerator DisableButtonAfterAnimation(Button button, float delay)
    {
        yield return new WaitForSeconds(delay);
        button.interactable = false;
        button.gameObject.SetActive(false);
    }
}
