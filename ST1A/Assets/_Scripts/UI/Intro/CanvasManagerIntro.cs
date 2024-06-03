using UnityEngine;

public class CanvasManagerIntro : MonoBehaviour
{
    public Canvas[] canvasesToDeactivate;
    public Canvas[] canvasesToActivate;
    public GameObject task1;
    private bool isTutorialActive = false;

    public void ToggleCanvases()
    {
        foreach (Canvas canvas in canvasesToDeactivate)
        {
            canvas.gameObject.SetActive(false);
        }

        foreach (Canvas canvas in canvasesToActivate)
        {
            canvas.gameObject.SetActive(true);
        }

        // Task 1 activate
        if (task1 != null)
        {
            task1.SetActive(true);
            isTutorialActive = true;
        }

        // Notify TutorialManager that the intro is completed
        TutorialManager.Instance.OnIntroCompleted();
    }
        public void DeactivateTutorialPanel()
    {
        if (isTutorialActive && task1 != null)
        {
            task1.SetActive(false);
            isTutorialActive = false;
        }
    }
}
