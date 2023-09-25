using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpMenu : MonoBehaviour
{
    public static bool helpMenuActivated = false;

    public GameObject pauseMenuScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (helpMenuActivated)
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
        pauseMenuScreen.SetActive(false);
        Time.timeScale = 1;
        helpMenuActivated = false;

    }
    public void pauseGame()
    {
        pauseMenuScreen.SetActive(true);
        Time.timeScale = 0;
        helpMenuActivated = true;
    }
    
}
