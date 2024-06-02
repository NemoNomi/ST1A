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

    [Header("Other Settings")]
    [Tooltip("The speech bubble button of the first NPC")]
    public Button firstNpcSpeechBubbleButton;

    [Tooltip("Arrow GameObject pointing to the first button")]
    public GameObject arrow;

    private NPCMovementManager npcMovementManager;

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
    }

    private void SetButtonInteractable(Button button, bool isInteractable)
    {
        button.interactable = isInteractable;
        ColorBlock colors = button.colors;
        colors.disabledColor = new Color(0.78f, 0.78f, 0.78f);
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

            // Play button animation
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
                // Set the animator bool to start the animation
                Animator animator = clickedButton.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetBool("IsClicked", true);
                }

                // Disable the button after the animation duration
                StartCoroutine(DisableButtonAfterAnimation(clickedButton, 0.5f)); 
            }
        }
        else
        {
            Debug.LogError("NPCMovementManager is not assigned.");
        }
    }

    private IEnumerator DisableButtonAfterAnimation(Button button, float delay)
    {
        yield return new WaitForSeconds(delay);
        button.interactable = false;
        button.gameObject.SetActive(false);
    }
}
