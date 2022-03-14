using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    float beatOfThisNote;
    [System.NonSerialized] public float t = 0.0f;
    bool gotToTrigger;
    bool exists;
    Transform spawn;
    Transform destroy;
    Transform trigger;

    void Update()
    {
        if(exists)
        {
            if(!gotToTrigger)
            {
                float t = (Conductor.Instance.song.BeatsShownInAdvance - (beatOfThisNote - Conductor.Instance.songPositionInBeats)) / Conductor.Instance.song.BeatsShownInAdvance;

                transform.position = Vector3.Lerp(spawn.position, trigger.position, t); 

                if(t >= 1f)
                {
                    Debug.Log("Beat Got To Trigger At Song Beat " + Conductor.Instance.songPositionInBeats);
                    gotToTrigger = true;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(trigger.position, destroy.position, t); 
                t += 0.001f;
            }
            
        }      
    }

    public void InitNote(Transform spawnPos, Transform destroyPos, Transform triggerPos, float beat)
    {
        spawn = spawnPos;
        destroy = destroyPos;
        trigger = triggerPos;
        beatOfThisNote = beat;
        exists = true;
    }
}
