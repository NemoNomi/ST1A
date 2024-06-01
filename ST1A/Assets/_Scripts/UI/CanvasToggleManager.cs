using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class NPCTargetCanvasHandler : MonoBehaviour
{
    public GameObject targetCanvas; // The Canvas object to be activated/deactivated
    public InputActionReference clickActionReference; // Reference to the click action from the Input Action Asset

    private void OnEnable()
    {
        clickActionReference.action.performed += OnClickPerformed;
        clickActionReference.action.Enable();
    }

    private void OnDisable()
    {
        clickActionReference.action.performed -= OnClickPerformed;
        clickActionReference.action.Disable();
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        Vector2 pointerPosition = Pointer.current.position.ReadValue();

        // Check if the pointer is over a UI element
        if (IsPointerOverUI(pointerPosition))
        {
            // Raycast to check if the UI element is over an NPC's head
            Ray ray = Camera.main.ScreenPointToRay(pointerPosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Check if the hit object is this NPC's UI element
                if (hit.transform == transform)
                {
                    // Toggle the target canvas
                    targetCanvas.SetActive(!targetCanvas.activeSelf);
                    return;
                }
            }
        }

        // Deactivate the canvas if active and clicked outside the object
        if (targetCanvas.activeSelf)
        {
            targetCanvas.SetActive(false);
        }
    }

    public void SetTargetCanvas(GameObject newTargetCanvas)
    {
        targetCanvas = newTargetCanvas;
    }

    private bool IsPointerOverUI(Vector2 pointerPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = pointerPosition
        };

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
