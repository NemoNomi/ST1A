using UnityEngine;
using UnityEngine.UI;

public class SatisfactionResetButton : MonoBehaviour
{
    public Button resetButton; 
    public Slider[] satisfactionSliders; 
    public SatisfactionManager satisfactionManager;
    public Canvas nextCanvas; 
    public Canvas canvasToDeactivateOnClick; 
    public float delayBeforeNextCanvas = 5.0f; 

    private void Start()
    {
        resetButton.onClick.AddListener(ResetSatisfaction);
    }

    private void ResetSatisfaction()
    {
        foreach (Slider slider in satisfactionSliders)
        {
            slider.value = 1.0f;
            satisfactionManager.UpdateSliderAppearance(slider); 
        }

        resetButton.gameObject.SetActive(false);
        gameObject.SetActive(false);

 
        if (canvasToDeactivateOnClick != null)
        {
            canvasToDeactivateOnClick.gameObject.SetActive(false);
        }

        Invoke("ActivateNextCanvas", delayBeforeNextCanvas);
    }

    private void ActivateNextCanvas()
    {
        if (nextCanvas != null)
        {
            nextCanvas.gameObject.SetActive(true);
        }
    }
}
