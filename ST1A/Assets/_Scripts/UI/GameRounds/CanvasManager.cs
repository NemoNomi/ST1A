using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas[] canvasesToDeactivate;
    public Canvas[] canvasesToActivate;

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
    }
}
