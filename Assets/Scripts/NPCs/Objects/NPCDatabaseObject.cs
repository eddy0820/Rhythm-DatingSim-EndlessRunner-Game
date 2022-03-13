using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Database", menuName = "Databases/NPC")]
public class NPCDatabaseObject : ScriptableObject
{
    [SerializeField] NPCObject[] NPCS;
    Dictionary<int, NPCObject> getNPC = new Dictionary<int, NPCObject>();
    public Dictionary<int, NPCObject> GetNPC => getNPC;

    public void InitNPCs()
    {
        getNPC = new Dictionary<int, NPCObject>();

        for(int i = 0; i < NPCS.Length; i++)
        {
            NPCS[i].currFameCost = NPCS[i].InitialFameCost;
            NPCS[i].currTimesShown = 0;
            getNPC.Add(i, NPCS[i]);
        }
    }
}
