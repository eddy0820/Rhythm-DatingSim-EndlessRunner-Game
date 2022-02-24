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
    [SerializeField] float[] notes;
    public float[] Notes => notes;
}
