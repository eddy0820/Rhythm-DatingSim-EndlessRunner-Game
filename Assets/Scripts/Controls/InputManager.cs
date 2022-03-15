using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls controls;
    PlayerControls.PlayerActions playerControls;
    Conductor conductor;
    PlayerController playerController;
    DialogueManager dialogueManager;

    private void Awake()
    {
        controls = new PlayerControls();
        playerControls = controls.Player;

        conductor = GetComponent<Conductor>();
        playerController = FindObjectOfType<PlayerController>();
        dialogueManager = GetComponent<DialogueManager>();
        
        playerControls.StartMusic.performed += _ =>
            conductor.StartMusic();

        playerControls.HitNote.performed += _ =>
            conductor.hitNote = true;

        playerControls.GoDown.performed += _ =>
            playerController.GoDown();

        playerControls.GoUp.performed += _ =>
            playerController.GoUp();

        playerControls.NextLine.performed += _ =>
            dialogueManager.OnNextLine();
    }

    private void Test(){Debug.Log("bruh");}

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
