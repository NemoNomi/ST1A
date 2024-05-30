using UnityEngine;
using UnityEngine.InputSystem;

public class CardInteraction : MonoBehaviour
{
    public GameObject canvas;
    public InputActionReference InputActionReference;
       private RectTransform canvasRectTransform;

    private void OnEnable()
    {
        InputActionReference.action.performed += OnClickPerformed;
        InputActionReference.action.Enable();
                if (canvas != null)
        {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }
    }

    private void OnDisable()
    {
        InputActionReference.action.performed -= OnClickPerformed;
        InputActionReference.action.Disable();
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Pointer.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform == transform)
            {
                canvas.SetActive(true);
            }
        }
    }
}
