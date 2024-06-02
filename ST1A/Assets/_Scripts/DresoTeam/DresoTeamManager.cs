using UnityEngine;

public class DresoTeamManager : MonoBehaviour
{
    [System.Serializable]
    public class DresoTeamMember
    {
        public GameObject member;  // The Dreso Team member GameObject
        public Transform targetPosition;  // The target position for the team member
    }

    [Header("Dreso Team Members")]
    public DresoTeamMember[] dresoTeamMembers;  // Array of Dreso Team members

    [Header("Canvas to Activate")]
    [Tooltip("The canvas to activate when all Dreso Team members reach their target positions")]
    public Canvas targetCanvas;  // The Canvas to activate when all members reach their targets

    private int membersReachedTarget = 0;  // Counter for members who have reached their targets

    private void Start()
    {
        // Ensure the target canvas is initially inactive
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Method to move the Dreso Team members to their target positions.
    /// This method can be called by the button's OnClick event.
    /// </summary>
    public void MoveDresoTeamToTargets()
    {
        foreach (var memberData in dresoTeamMembers)
        {
            if (memberData.member != null && memberData.targetPosition != null)
            {
                DresoTeamMovementController movementController = memberData.member.GetComponent<DresoTeamMovementController>();
                if (movementController != null)
                {
                    movementController.OnTargetReached += OnMemberReachedTarget;
                    movementController.MoveTo(memberData.targetPosition.position);
                }
                else
                {
                    Debug.LogError("DresoTeamMovementController component is missing on the team member: " + memberData.member.name);
                }
            }
            else
            {
                Debug.LogError("Member or target position is not assigned for one of the Dreso team members.");
            }
        }
    }

    private void OnMemberReachedTarget()
    {
        membersReachedTarget++;
        Debug.Log($"Member reached target. Total members reached: {membersReachedTarget}");

        // Check if all members have reached their targets
        if (membersReachedTarget == dresoTeamMembers.Length)
        {
            ActivateTargetCanvas();
        }
    }

    private void ActivateTargetCanvas()
    {
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(true);
            Debug.Log("Target canvas activated.");
        }
    }
}
