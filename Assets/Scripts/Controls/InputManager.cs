using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls controls;
    PlayerControls.PlayerActions playerControls;
    Conductor conductor;
    private void Awake()
    {
        controls = new PlayerControls();
        playerControls = controls.Player;

        conductor = GetComponent<Conductor>();
        
        playerControls.StartMusic.performed += _ =>
            conductor.StartMusic();

        playerControls.HitNote.performed += _ =>
            Test();
        
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
