using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Note")
        {
            if(Conductor.Instance.hitNote)
            {
                Destroy(other.gameObject);
                Conductor.Instance.hitNote = false;
            }
        }
    }
}
