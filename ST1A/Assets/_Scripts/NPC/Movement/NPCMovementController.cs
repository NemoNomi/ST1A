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

    // Reference to the CanvasManagerIntro to manage panels
    [SerializeField]
    private CanvasManagerIntro _canvasManagerIntro;

    // Tolerance to determine if the NPC has reached the target position
    [SerializeField]
    private float _targetTolerance = 0.1f;

    // Flag to track if movement has started
    private bool _isMoving = false;

    // Reference to the Animator component
    private Animator _animator;

    // Reference to the Main Camera
    private Camera _mainCamera;

    // Rotation speed
    [SerializeField]
    private float rotationSpeed = 2.0f;

    // NPC Index to identify which NPC this is
    [SerializeField]
    private int npcIndex;

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

        // Get the Animator component
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator component is missing on the NPC.");
        }

        // Get the Main Camera
        _mainCamera = Camera.main;
        if (_mainCamera == null)
        {
            Debug.LogError("Main Camera is not found.");
        }

        // Get the CanvasManagerIntro component
        if (_canvasManagerIntro == null)
        {
            Debug.LogError("CanvasManagerIntro component is not assigned.");
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

                // Notify the TutorialManager that the NPC has reached the target
                TutorialManager.Instance.OnNPCReachedTarget(npcIndex);

                // Activate the target Canvas
                if (_targetCanvas != null)
                {
                    _targetCanvas.gameObject.SetActive(true);
                }

                // Deactivate the tutorial panel
                if (_canvasManagerIntro != null)
                {
                    _canvasManagerIntro.DeactivateTutorialPanel();
                }

                // Set the Animator parameter to Idle
                if (_animator != null)
                {
                    _animator.SetBool("isWalking", false);
                }
            }
        }
        else
        {
            // Smoothly rotate towards the camera when not moving
            LookAtCamera();
        }
    }

    void LateUpdate()
    {
        if (_animator != null)
        {
            // Check if the NPC is moving and update the animator
            if (_isMoving)
            {
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _animator.SetBool("isWalking", false);
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

    #region Private Methods
    /// <summary>
    /// Makes the NPC look at the camera.
    /// </summary>
    private void LookAtCamera()
    {
        if (_mainCamera != null)
        {
            Vector3 direction = (_mainCamera.transform.position - transform.position).normalized;
            direction.y = 0;  // Keep the NPC upright
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
    #endregion
}
#endregion
