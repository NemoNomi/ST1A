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
}
