using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    public GameObject CreditsPanel;
    public GameObject UI_Panel;

    public void Start()
    {
        UI_Panel.SetActive(true);
        CreditsPanel.SetActive(false);
    }
    public void Button_StartGame()
    {
        //Load the Scene with int 1
        SceneManager.LoadScene("mainScene");

    }


    public void Button_Settings()
    {

    }

    public void Button_Credits()
    {
        UI_Panel.SetActive(false);
        CreditsPanel.SetActive(true);
        
    }
    public void Button_Exit_Credits()
    {
        UI_Panel.SetActive(true);
        CreditsPanel.SetActive(false);

    }


    public void Button_QuitGame()
    {
        Application.Quit();
    }

}
