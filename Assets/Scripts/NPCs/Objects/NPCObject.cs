using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField] Dialogue npcDialogue;
    public Dialogue NPCDialogue => npcDialogue;
    [SerializeField] Sprite dialogueBox;
    public Sprite DialogueBox => dialogueBox;
    [SerializeField] TMP_FontAsset font;
    public TMP_FontAsset Font => font;
    [SerializeField] Color dialogueColor1;
    public Color DialogueColor1 => dialogueColor1;
    [SerializeField] Color dialogueColor2;
    public Color DialogueColor2 => dialogueColor2;
    [System.NonSerialized] public int currFameCost = 0;
    [System.NonSerialized] public int currTimesShown = 0;


    [System.Serializable]
    public class Dialogue
    {
        public Line[] sentences;

        [System.Serializable]
        public class Line
        {
            public string speaker; 

            [TextArea(3, 10)]
            public string sentance;
        }
    }
}
