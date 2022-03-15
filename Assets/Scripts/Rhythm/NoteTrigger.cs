using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    [Range(1, 4)]
    public int lane;
    PlayerController playerController;
    public FameCurrency FC;
    public AudioClip clip;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        FC = FindObjectOfType<FameCurrency>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Note")
        {
            if(Conductor.Instance.hitNote && playerController.currentLane == lane)
            {
                Destroy(other.gameObject);
                AudioSource.PlayClipAtPoint(clip, transform.position);
                Conductor.Instance.hitNote = false;
                FC.ChangeFame(5); 
            }
        }
    }
}
