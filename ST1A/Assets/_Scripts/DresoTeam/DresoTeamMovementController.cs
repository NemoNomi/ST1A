using UnityEngine;
using UnityEngine.AI;

public class DresoTeamMovementController : MonoBehaviour
{
    #region Fields
    // Reference to the NavMeshAgent component
    private NavMeshAgent _navMeshAgent;

    // Reference to the target position
    private Vector3 _targetPosition;

    // Tolerance to determine if the agent has reached the target position
    [SerializeField]
    private float _targetTolerance = 0.1f;

    // Flag to track if movement has started
    private bool _isMoving = false;

    // Reference to the Animator component
    private Animator _animator;

    // Event to notify when the agent reaches the target
    public event System.Action OnTargetReached;
    #endregion

    #region Unity Methods
    /// <summary>
    /// Initializes the movement controller.
    /// </summary>
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
                }
            }
        }
    }

    #endregion

    #region Public Methods
    /// <summary>
    /// Moves the agent to the specified target position using the NavMeshAgent.
    /// </summary>
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
        }
    }
    #endregion
}
