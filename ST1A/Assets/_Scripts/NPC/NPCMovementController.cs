using UnityEngine;

#region Class Definition
/// <summary>
/// Controls the NPC movement by using a movement controller that implements the IMovementController interface.
/// </summary>
public class NPCMovementController : MonoBehaviour
{
    #region Fields
    // Reference to the movement controller implementing the IMovementController interface
    private IMovementController _movementController;
    #endregion

    #region Unity Methods
    /// <summary>
    /// Initializes the movement controller.
    /// </summary>
    void Awake()
    {
        // Get the IMovementController component attached to this GameObject
        _movementController = GetComponent<IMovementController>();
        if (_movementController == null)
        {
            Debug.LogError("IMovementController component is missing on the NPC.");
        }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Moves the NPC to the specified target position using the movement controller.
    /// </summary>
    public void MoveTo(Vector3 targetPosition)
    {
        if (_movementController != null)
        {
            // Move the NPC to the target position
            _movementController.MoveTo(targetPosition);
        }
    }
    #endregion
}
#endregion
