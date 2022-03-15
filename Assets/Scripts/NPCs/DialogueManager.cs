using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<NPCObject.Dialogue.Line> sentences;
    public GameObject PlayerDialogue;
    public GameObject NPCDialogue;
    public TextMeshProUGUI DialogueText1;
    public TextMeshProUGUI DialogueText2;
    bool inDialogue;
 

    private void Start()
    {
        sentences = new Queue<NPCObject.Dialogue.Line>();
    }

    public void StartDialogue(NPCObject.Dialogue dialogue)
    {
        sentences.Clear();

        foreach(NPCObject.Dialogue.Line line in dialogue.sentences)
        {
            sentences.Enqueue(line);
        }

        inDialogue = true;

        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        NPCObject.Dialogue.Line line = sentences.Dequeue();

        if(line.speaker == "Kpeakes, The Endless Runner")
        {
            NPCDialogue.SetActive(false);
            PlayerDialogue.SetActive(true);
        }
        else
        {
            PlayerDialogue.SetActive(false);
            NPCDialogue.SetActive(true);
        }

        DialogueText1.gameObject.SetActive(true);
        DialogueText2.gameObject.SetActive(true);

        DialogueText1.text = line.sentance;
        DialogueText2.text = line.sentance;
        
    }

    private void EndDialogue()
    {
        inDialogue = false;
        NPCDialogue.SetActive(false);
        PlayerDialogue.SetActive(false);
        DialogueText1.gameObject.SetActive(false);
        DialogueText2.gameObject.SetActive(false);

        GetComponent<Conductor>().GoToNextSong();
    }

    public void OnNextLine()
    {
        if(inDialogue)
        {
            DisplayNextSentance();
        }
    }
}
