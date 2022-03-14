using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    [Range(1, 4)]
    public int lane;
    PlayerController playerController;
    public FameCurrency FC;

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
                Conductor.Instance.hitNote = false;
                FC.ChangeFame(10); 
            }
        }
    }
}
