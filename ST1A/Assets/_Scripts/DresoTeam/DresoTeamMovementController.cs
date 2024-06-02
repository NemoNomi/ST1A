using UnityEngine;
using UnityEngine.AI;

public class DresoTeamMovementController : MonoBehaviour
{
    #region Fields
    private NavMeshAgent _navMeshAgent;  // Reference to the NavMeshAgent component
    private Vector3 _targetPosition;  // Reference to the target position
    [SerializeField]
    private float _targetTolerance = 0.1f;  // Tolerance to determine if the agent has reached the target position
    private bool _isMoving = false;  // Flag to track if movement has started
    private Animator _animator;  // Reference to the Animator component
    private Camera _mainCamera;  // Reference to the Main Camera
    [SerializeField]
    private float rotationSpeed = 2.0f;  // Rotation speed
    private bool _shouldLookAtCamera = false;  // Flag to indicate if the agent should look at the camera
    public event System.Action OnTargetReached;  // Event to notify when the agent reaches the target
    #endregion

    #region Unity Methods
    void Awake()
    {
        // Get the NavMeshAgent component attached to this GameObject
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on the Dreso Team member.");
        }

        // Get the Animator component
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator component is missing on the Dreso Team member.");
        }

        // Get the Main Camera
        _mainCamera = Camera.main;
        if (_mainCamera == null)
        {
            Debug.LogError("Main Camera is not found.");
        }
    }

    void Update()
    {
        if (_isMoving && _navMeshAgent != null)
        {
            // Check if the agent has reached the target position within the tolerance
            if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _targetTolerance)
            {
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    // Stop the movement
                    _isMoving = false;

                    // Trigger the target reached event
                    OnTargetReached?.Invoke();

                    // Set the Animator parameter to Idle
                    if (_animator != null)
                    {
                        _animator.SetBool("isWalking", false);
                    }

                    // Enable camera look
                    _shouldLookAtCamera = true;
                }
            }
        }

        // Rotate towards the camera if needed
        if (_shouldLookAtCamera)
        {
            LookAtCamera();
        }
    }
    #endregion

    #region Public Methods
    public void MoveTo(Vector3 targetPosition)
    {
        if (_navMeshAgent != null)
        {
            // Set the target position
            _targetPosition = targetPosition;

            // Start the movement
            _isMoving = true;

            // Move the agent to the target position
            _navMeshAgent.SetDestination(targetPosition);

            // Set the Animator parameter to Walking
            if (_animator != null)
            {
                _animator.SetBool("isWalking", true);
            }

            // Disable camera look while moving
            _shouldLookAtCamera = false;
        }
    }
    #endregion

    #region Private Methods
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
