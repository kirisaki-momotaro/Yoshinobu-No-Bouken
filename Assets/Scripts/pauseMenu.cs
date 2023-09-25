using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPaused=false;

    public GameObject pauseMenuScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }
    public void resumeGame()
    {
        pauseMenuScreen. SetActive(false);
        Time.timeScale = 1;
        isPaused = false;

    }
    public void pauseGame()
    {
        pauseMenuScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void mainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }
}
