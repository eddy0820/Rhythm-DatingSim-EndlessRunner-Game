using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void Return()
    {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame()
    {
        Debug.Log("You have quit the game.");
        Application.Quit();        
    }
}
