using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPCObject : ScriptableObject
{
    [SerializeField] new string name;
    public string Name => name;
    [SerializeField] SongObject song;
    public SongObject Song => song;
    [SerializeField] int initialFameCost;
    public int InitialFameCost => initialFameCost;
    [SerializeField] float fameScaleFactor;
    public float FameScaleFactor => fameScaleFactor;
    [System.NonSerialized] public int currFameCost = 0;
    [System.NonSerialized] public int currTimesShown = 0;
    // Sprite
    // Animator
    // Dialogue
}
