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

    // Reference to the target position
    private Vector3 _targetPosition;

    // Reference to the Canvas to activate
    [SerializeField]
    private Canvas _targetCanvas;

    // Tolerance to determine if the NPC has reached the target position
    [SerializeField]
    private float _targetTolerance = 0.1f;

    // Flag to track if movement has started
    private bool _isMoving = false;
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

        // Ensure the Canvas is initially inactive
        if (_targetCanvas != null)
        {
            _targetCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Target Canvas is not assigned.");
        }
    }

    void Update()
    {
        if (_isMoving && _movementController != null)
        {
            // Check if the NPC has reached the target position
            if (Vector3.Distance(transform.position, _targetPosition) <= _targetTolerance)
            {
                // Stop the movement
                _isMoving = false;

                // Activate the target Canvas
                if (_targetCanvas != null)
                {
                    _targetCanvas.gameObject.SetActive(true);
                }
            }
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
            // Set the target position
            _targetPosition = targetPosition;

            // Start the movement
            _isMoving = true;

            // Move the NPC to the target position
            _movementController.MoveTo(targetPosition);
        }
    }
    #endregion
}
#endregion
