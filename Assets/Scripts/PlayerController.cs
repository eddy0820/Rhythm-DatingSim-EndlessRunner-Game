using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerLoc1;
    public Transform playerLoc2;
    public Transform playerLoc3;
    public Transform playerLoc4;

    [System.NonSerialized] public int currentLane;
    bool isDirty;

    AudioSource musicSource;

    void Awake()
    {
        musicSource = FindObjectOfType<Conductor>().GetComponent<AudioSource>();
    }

    void Start()
    {
        transform.position = playerLoc1.position;
        currentLane = 1;
    }

    void Update()
    {
        if(isDirty)
        {
            if(musicSource.isPlaying)
            {
                switch(currentLane) 
                {
                    case 1:
                        transform.position = playerLoc1.position;
                        break;
                    case 2:
                        transform.position = playerLoc2.position;
                        break;
                    case 3:
                        transform.position = playerLoc3.position;
                        break;
                    case 4:
                        transform.position = playerLoc4.position;
                        break;
                }

                isDirty = false;
            }
        }
    }

    public void GoDown()
    {
        if(currentLane < 4)
        {
            currentLane++;
            isDirty = true;
        }
    }
    
    public void GoUp()
    {
        if(currentLane > 1)
        {
            currentLane--;
            isDirty = true;
        }
    }
}
