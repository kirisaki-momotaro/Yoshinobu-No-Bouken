using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMenuWinScene : MonoBehaviour
{
    public void backToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
