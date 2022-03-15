using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuGameObject;
    public GameObject startObject;
    public GameObject spawingSpotObject;

    void Start()
    {
        Resume();   //This is to make sure the game doesn't load initally into a paused state.  
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (gameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Time.timeScale = 0f;
            gameIsPaused = true;

            if (Input.GetKeyDown(KeyCode.P))
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenuGameObject.SetActive(false);
        spawingSpotObject.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
       //AudioListener.pause = false;
    }

    void Pause()
    {
        pauseMenuGameObject.SetActive(true);
        startObject.SetActive(false);
        spawingSpotObject.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        //AudioListener.pause = true;
        PauseAllSources();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PauseAllSources()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach(AudioSource a in allAudioSources)
        {
            if (a.isActiveAndEnabled == true)
            {
                if (a.isPlaying) a.Pause();
                else a.UnPause();
            }
        }

    }

}
