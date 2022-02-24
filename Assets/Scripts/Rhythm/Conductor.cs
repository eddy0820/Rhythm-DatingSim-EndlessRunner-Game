using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Conductor : MonoBehaviour
{
    [SerializeField] SongObject song;
    // This is determined by the song you're trying to sync up to
    [ReadOnly, SerializeField] float songBpm;
    // The number of seconds for each song beat.
    [ReadOnly, SerializeField] float secPerBeat;
    // Current song position, in seconds.
    [ReadOnly, SerializeField] float songPosition;
    // Current song position, in beats.
    [ReadOnly, SerializeField] float songPositionInBeats;
    // How many seconds have passed since the song started.
    int nextIndex = 0;
    float dspSongTime;
    AudioSource musicSource;

    private void Awake()
    {
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

            if (nextIndex < song.Notes.Length && song.Notes[nextIndex] < songPositionInBeats + song.BeatsShownInAdvance)
            {
                //Instantiate( /* Music Note Prefab */ );
                Debug.Log("spawned beat");
                //initialize the fields of the music note

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
