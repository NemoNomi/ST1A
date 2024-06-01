using UnityEngine;

public class NPCMovementManager : MonoBehaviour
{
    [System.Serializable]
    public class NPCMovementData
    {
        public GameObject npc;  // The NPC GameObject
        public Transform targetPosition;  // The target position where the NPC will move to
    }

    public NPCMovementData[] npcMovementDataArray;  // Array of NPC movement data

    /// <summary>
    /// Moves the specified NPC to its target position.
    /// </summary>
    public void MoveNPC(int npcIndex)
    {
        if (npcIndex < 0 || npcIndex >= npcMovementDataArray.Length)
        {
            Debug.LogError("Invalid NPC index: " + npcIndex);
            return;
        }

        var npcData = npcMovementDataArray[npcIndex];

        if (npcData.npc != null && npcData.targetPosition != null)
        {
            NPCMovementController movementController = npcData.npc.GetComponent<NPCMovementController>();
            if (movementController != null)
            {
                movementController.MoveTo(npcData.targetPosition.position);
            }
            else
            {
                Debug.LogError("NPCMovementController component is missing on the NPC: " + npcData.npc.name);
            }
        }
        else
        {
            Debug.LogError("NPC or target position is not assigned for NPC index: " + npcIndex);
        }
    }
}
