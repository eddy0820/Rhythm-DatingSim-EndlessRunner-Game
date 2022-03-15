using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Conductor : MonoBehaviour
{
    public static Conductor Instance {get; private set; }

    [Header("Song")]
    public SongObject song;
    
    [Header("Lane 1 Positions")]
    [SerializeField] Transform spawn1;
    [SerializeField] Transform destroy1;
    [SerializeField] Transform trigger1;

    [Header("Lane 2 Positions")]
    [SerializeField] Transform spawn2;
    [SerializeField] Transform destroy2;
    [SerializeField] Transform trigger2;

    [Header("Lane 3 Positions")]
    [SerializeField] Transform spawn3;
    [SerializeField] Transform destroy3;
    [SerializeField] Transform trigger3;

    [Header("Lane 4 Positions")]
    [SerializeField] Transform spawn4;
    [SerializeField] Transform destroy4;
    [SerializeField] Transform trigger4;

    [Header("NPC Locs")]
    public Transform NPCLoc1;
    public Transform NPCLoc2;
    public Transform NPCLoc3;
    public Transform NPCLoc4;

    [Header("Player Dest Locs")]
    public Transform playerDestLoc1;
    public Transform playerDestLoc2;
    public Transform playerDestLoc3;
    public Transform playerDestLoc4;

    [Header("NPC Dest Locs")]
    public Transform NPCDestLoc1;
    public Transform NPCDestLoc2;
    public Transform NPCDestLoc3;
    public Transform NPCDestLoc4;
    
    [Header("Note Prefab")]
    [SerializeField] GameObject notePrefab;

    [Header("NPC")]
    [SerializeField] GameObject NPCGameObject;

    [Header("Databases")]
    [SerializeField] NPCDatabaseObject NPCDatabase;

    [Header("Read Only")]
    [ReadOnly, SerializeField] float songBpm;

    [ReadOnly, SerializeField] float secPerBeat;

    [ReadOnly, SerializeField] float songPosition;

    [ReadOnly] public float songPositionInBeats;


    Transform spawnPosition;
    Transform destroyPosition;
    Transform triggerPosition;
    Transform playerDestLoc;
    Transform NPCDestLoc;

    [System.NonSerialized] public bool hitNote;
    [System.NonSerialized] public int nextIndex = 0;
    float dspSongTime;
    AudioSource musicSource;
    FameCurrency fameCurrency;
    bool NPCChecked;
    PlayerController playerController;
    bool playerDone;
    bool NPCDone;
    NPCObject currNPC;
    Vector3 NPCStartLoc;
    SongObject idleSong;

    private void Awake()
    {
        Instance = this;

        musicSource = GetComponent<AudioSource>();
        musicSource.clip = song.Song;

        songBpm = song.BPM;
        secPerBeat = 60f / songBpm;

        nextIndex = 0;

        fameCurrency = Camera.main.GetComponent<FameCurrency>();
        NPCDatabase.InitNPCs();

        playerController = FindObjectOfType<PlayerController>();

        /////////////////////////////
        NPCChecked = true;
        NPCStartLoc = new Vector3(-6.88f, 1.6f, 3);

        idleSong = song;
    }

    private void Update()
    {
        if(!PauseMenu.gameIsPaused)
        {
            if(!musicSource.isPlaying && nextIndex >= song.Notes.Length)
            {
                nextIndex = 0;

                if(!NPCChecked) // needs to be set to false somewhere
                {
                    // Chooses NPC
                    int randNum = UnityEngine.Random.Range(0, NPCDatabase.GetNPC.Count);
                    currNPC = NPCDatabase.GetNPC[randNum];

                    if(NPCDatabase.GetNPC[randNum].currFameCost <= fameCurrency.count)
                    {
                        // Scales their fame cost
                        if(NPCDatabase.GetNPC[randNum].currTimesShown > 0)
                        {
                            float temp = NPCDatabase.GetNPC[randNum].currFameCost + (NPCDatabase.GetNPC[randNum].currFameCost * NPCDatabase.GetNPC[randNum].FameScaleFactor);
                            NPCDatabase.GetNPC[randNum].currFameCost = (int) temp;
                        }

                        // Sets the NPCs lane to the players
                        switch(playerController.currentLane) 
                        {
                            case 1:
                                NPCGameObject.transform.position = NPCLoc1.position;
                                playerDestLoc = playerDestLoc1;
                                NPCDestLoc = NPCDestLoc1;
                                break;
                            case 2:
                                NPCGameObject.transform.position = NPCLoc2.position;
                                playerDestLoc = playerDestLoc2;
                                NPCDestLoc = NPCDestLoc2;
                                break;
                            case 3:
                                NPCGameObject.transform.position = NPCLoc3.position;
                                playerDestLoc = playerDestLoc3;
                                NPCDestLoc = NPCDestLoc3;
                                break;
                            case 4:
                                NPCGameObject.transform.position = NPCLoc4.position;
                                playerDestLoc = playerDestLoc4;
                                NPCDestLoc = NPCDestLoc4;
                                break;
                        }

                        // Moves the characters towards each other
                        StartCoroutine(LerpPlayer(playerController.gameObject.transform.position, playerDestLoc.position));
                        StartCoroutine(LerpNPC());

                        NPCDatabase.GetNPC[randNum].currTimesShown++;
                    }
                    else
                    {
                        song = idleSong;
                        musicSource.clip = song.Song;
                        StartMusic();
                    }
                    
                    NPCChecked = true;
                } 
            }

            if(playerDone && NPCDone)
            {
                playerDone = false;
                NPCDone = false;
                GetComponent<DialogueManager>().StartDialogue(currNPC.NPCDialogue);
            }
            else if(playerDone)
            {
                playerDone = false;
                song = currNPC.Song;
                musicSource.clip = song.Song;
                StartMusic();

            }
        }
    }

    public void StartMusic()
    {
        // Record the time when the music starts.
        dspSongTime = (float) AudioSettings.dspTime;

        musicSource.Play();

        StartCoroutine(PlaySong());
    }

    IEnumerator PlaySong()
    {
        while(musicSource.isPlaying)
        {
            /////////////////////////////
            NPCChecked = false;
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

            yield return null;
        }

        yield break;
    }

    IEnumerator LerpPlayer(Vector3 _start, Vector3 _end)
    {
        float t = 0;
        Vector3 start = _start;
        while(t < 1)
        {
            playerController.gameObject.transform.position = Vector3.Lerp(start, _end, t); 
            t += 0.001f;
            yield return null;
        }

        playerDone = true;

        yield break;
    }

    IEnumerator LerpNPC()
    {
        float t = 0;
        Vector3 start = NPCGameObject.transform.position;
        while(t < 1)
        {
            NPCGameObject.transform.position = Vector3.Lerp(start, NPCDestLoc.position, t); 
            t += 0.001f;
            yield return null;
        }

        NPCDone = true;
        yield break;
    }

    public void GoToNextSong()
    {
        NPCGameObject.transform.position = NPCStartLoc;
        StartCoroutine(LerpPlayer(playerController.gameObject.transform.position, playerController.playerLoc));
    }

}
