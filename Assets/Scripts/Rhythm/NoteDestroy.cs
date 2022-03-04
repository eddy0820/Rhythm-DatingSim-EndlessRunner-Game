using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDestroy : MonoBehaviour
{
    public FameCurrency FC;

    void Start()
    {
        FC = FindObjectOfType<FameCurrency>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Note")
        {
            FC.ChangeFame(-10);
            Destroy(other.gameObject);
        }
    }
}
