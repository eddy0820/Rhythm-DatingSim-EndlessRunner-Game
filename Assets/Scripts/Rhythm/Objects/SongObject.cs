using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "Song")]
public class SongObject : ScriptableObject
{
    [SerializeField] AudioClip song;
    public AudioClip Song => song;
    [SerializeField] float bpm;
    public float BPM => bpm;
    [SerializeField] float beatsShownInAdvance;
    public float BeatsShownInAdvance => beatsShownInAdvance;
    [SerializeField] SongObject.Note[] notes;
    public SongObject.Note[] Notes => notes;

    [System.Serializable]
    public class Note
    {
        [SerializeField] float beat;

        [Range(1, 4)]
        [SerializeField] int lane;

        public float Beat => beat;

        public int Lane => lane;
    }
}
