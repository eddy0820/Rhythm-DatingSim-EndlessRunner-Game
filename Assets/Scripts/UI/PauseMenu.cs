using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuGameObject;
    public GameObject startObject;
    public AudioSource backgroundMusic;

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
        Time.timeScale = 1f;
        gameIsPaused = false;
        backgroundMusic.Play();
    }

    void Pause()
    {
        pauseMenuGameObject.SetActive(true);
        startObject.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        backgroundMusic.Pause();

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
