using System.Collections.Generic;
using UnityEngine;

#region Class Definition
/// <summary>
/// Manages NPC instances in the scene.
/// </summary>
public class NPCInstancesManager : MonoBehaviour
{
    #region Fields
    private List<GameObject> activeNPCs = new List<GameObject>();
    #endregion

    #region Public Methods
    /// <summary>
    /// Registers an NPC in the scene.
    /// </summary>
    /// <param name="npcInstance">The NPC instance.</param>
    public void RegisterNPC(GameObject npcInstance)
    {
        if (!activeNPCs.Contains(npcInstance))
        {
            activeNPCs.Add(npcInstance);
        }
    }

    /// <summary>
    /// Unregisters an NPC from the scene.
    /// </summary>
    /// <param name="npcInstance">The NPC instance.</param>
    public void UnregisterNPC(GameObject npcInstance)
    {
        if (activeNPCs.Contains(npcInstance))
        {
            activeNPCs.Remove(npcInstance);
        }
    }

    /// <summary>
    /// Checks if an NPC with the given prefab is already in the scene.
    /// </summary>
    /// <param name="npcPrefab">The prefab of the NPC.</param>
    /// <returns>True if the NPC is in the scene, otherwise false.</returns>
    public bool IsNPCInScene(GameObject npcPrefab)
    {
        foreach (var npc in activeNPCs)
        {
            if (npcPrefab.name == npc.name)
            {
                return true;
            }
        }
        return false;
    }
    #endregion
}
#endregion
