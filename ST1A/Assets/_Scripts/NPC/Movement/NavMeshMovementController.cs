using UnityEngine;
using UnityEngine.AI;

#region Class Definition
/// <summary>
/// Controls the movement of an NPC using NavMeshAgent.
/// Implements the IMovementController interface.
/// </summary>
public class NavMeshMovementController : MonoBehaviour, IMovementController
{
    #region Fields
    // Reference to the NavMeshAgent component
    private NavMeshAgent _agent;
    #endregion

    #region Unity Methods
    /// <summary>
    /// Initializes the NavMeshAgent component.
    /// </summary>
    void Start()
    {
        // Get the NavMeshAgent component attached to this GameObject
        _agent = GetComponent<NavMeshAgent>();

        // Check if the NavMeshAgent component is missing and log an error if it is
        if (_agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on the NPC.");
        }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Moves the NPC to the specified target position using the NavMeshAgent.
    /// </summary>
    public void MoveTo(Vector3 targetPosition)
    {
        if (_agent != null)
        {
            // Set the destination of the NavMeshAgent to the target position
            _agent.SetDestination(targetPosition);
        }
    }
    #endregion
}
#endregion
