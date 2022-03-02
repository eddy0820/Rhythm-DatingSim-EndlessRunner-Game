using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Conductor : MonoBehaviour
{
    public static Conductor Instance {get; private set; }

    [Header("Song")]
    public SongObject song;
    
    [Header("Lane 1 Positions")]
    public Transform spawn1;
    public Transform destroy1;
    public Transform trigger1;

    [Header("Lane 2 Positions")]
    public Transform spawn2;
    public Transform destroy2;
    public Transform trigger2;

    [Header("Lane 3 Positions")]
    public Transform spawn3;
    public Transform destroy3;
    public Transform trigger3;

    [Header("Lane 4 Positions")]
    public Transform spawn4;
    public Transform destroy4;
    public Transform trigger4;
    
    [Header("Note Prefab")]
    [SerializeField] GameObject notePrefab;

    [Header("Read Only")]
    [ReadOnly, SerializeField] float songBpm;

    [ReadOnly, SerializeField] float secPerBeat;

    [ReadOnly, SerializeField] float songPosition;

    [ReadOnly] public float songPositionInBeats;


    Transform spawnPosition;
    Transform destroyPosition;
    Transform triggerPosition;

    [System.NonSerialized] public bool hitNote;
    [System.NonSerialized] public int nextIndex = 0;
    float dspSongTime;
    AudioSource musicSource;

    private void Awake()
    {
        Instance = this;

        musicSource = GetComponent<AudioSource>();
        musicSource.clip = song.Song;

        songBpm = song.BPM;
        secPerBeat = 60f / songBpm;

        nextIndex = 0;
    }

    private void Update()
    {
        if(musicSource.isPlaying)
        {
            // Determine how many seconds since the song started.
            songPosition = (float) (AudioSettings.dspTime - dspSongTime);

            // Determine how many beats since the song started.
            songPositionInBeats = songPosition / secPerBeat;

            if (nextIndex < song.Notes.Length && song.Notes[nextIndex].Beat < songPositionInBeats + song.BeatsShownInAdvance)
            {
                switch(song.Notes[nextIndex].Lane) 
                {
                    case 1:
                        spawnPosition = spawn1;
                        destroyPosition = destroy1;
                        triggerPosition = trigger1;
                        break;
                    case 2:
                        spawnPosition = spawn2;
                        destroyPosition = destroy2;
                        triggerPosition = trigger2;
                        break;
                    case 3:
                        spawnPosition = spawn3;
                        destroyPosition = destroy3;
                        triggerPosition = trigger3;
                        break;
                    case 4:
                        spawnPosition = spawn4;
                        destroyPosition = destroy4;
                        triggerPosition = trigger4;
                        break;
                }

                Debug.Log("Spawned Beat At Song Beat " + songPositionInBeats);

                GameObject note = Instantiate(notePrefab, spawnPosition.position, notePrefab.transform.rotation);
                
                note.GetComponent<Note>().InitNote(spawnPosition, destroyPosition, triggerPosition, song.Notes[nextIndex].Beat);

                nextIndex++;
            }
        }
    }

    public void StartMusic()
    {
        // Record the time when the music starts.
        dspSongTime = (float) AudioSettings.dspTime;

        musicSource.Play();
    }
}
