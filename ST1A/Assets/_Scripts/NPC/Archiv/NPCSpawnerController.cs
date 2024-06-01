using UnityEngine;
using System.Collections;

#region Class Definition
/// <summary>
/// Handles spawning and moving NPCs based on specified data.
/// </summary>
public class NPCSpawnerController : MonoBehaviour
{
    #region Structs
    /// <summary>
    /// Holds data for spawning and moving an NPC.
    /// </summary>
    [System.Serializable]
    public struct NPCData
    {
        public GameObject npcPrefab;     // The prefab for the NPC
        public Transform spawnPosition;  // The position where the NPC will spawn
        public Transform targetPosition; // The target position where the NPC will move to
    }
    #endregion

    #region Fields
    public NPCData[] npcDataArray;      // Array of NPC data
    private NPCInstancesManager npcManager;      // Reference to the NPC manager
    private UINPCInstancesManager uiNPCInstancesManager;        // Reference to the UI manager
    #endregion

    #region Unity Methods
    void Awake()
    {
        npcManager = FindObjectOfType<NPCInstancesManager>();
        uiNPCInstancesManager = FindObjectOfType<UINPCInstancesManager>();
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Spawns and moves the NPC based on the given index.
    /// </summary>
    /// <param name="index">Index of the NPC data in the array.</param>
    public void SpawnNPC(int index)
    {
        if (index < 0 || index >= npcDataArray.Length)
        {
            Debug.LogError("Invalid NPC index: " + index);
            return;
        }

        NPCData npcData = npcDataArray[index];

        // Check if an NPC of this type already exists in the scene
        if (npcManager.IsNPCInScene(npcData.npcPrefab))
        {
            // Show error message if NPC is already in the scene
            uiNPCInstancesManager.ShowMessage();
            return;
        }

        StartCoroutine(SpawnAndMoveNPC(npcData));
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Coroutine to spawn the NPC and move it to the target position.
    /// </summary>
    /// <param name="npcData">The NPC data used for spawning and moving.</param>
    /// <returns>IEnumerator for coroutine.</returns>
    private IEnumerator SpawnAndMoveNPC(NPCData npcData)
    {
        // Check if SpawnPoint and TargetPoint are assigned
        if (npcData.spawnPosition == null || npcData.targetPosition == null)
        {
            Debug.LogError("Spawn Position or Target Position is not assigned in NPC data.");
            yield break;
        }

        // Spawn the NPC at the Spawn Point
        GameObject npcInstance = Instantiate(npcData.npcPrefab, npcData.spawnPosition.position, npcData.spawnPosition.rotation);
        npcInstance.name = npcData.npcPrefab.name; // Set the name of the NPC instance

        // Register the NPC with the NPC manager
        npcManager.RegisterNPC(npcInstance);

        // Wait for a few seconds
        yield return new WaitForSeconds(1f);

        // Move the NPC to the target position
        NPCMovementController npcMovementController = npcInstance.GetComponent<NPCMovementController>();
        if (npcMovementController != null)
        {
            npcMovementController.MoveTo(npcData.targetPosition.position);
        }
        else
        {
            Debug.LogError("NPCMovementController component is missing on the NPC prefab.");
        }
    }
    #endregion
}
#endregion
