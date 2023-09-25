using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class goalMeter : MonoBehaviour
{
    // Start is called before the first frame update
    public float zombiesLeft=0;
    public float totalZombies=0;
    public TextMeshProUGUI completionPercentage;
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(zombiesLeft + "," + totalZombies);
        if (zombiesLeft == 0 && totalZombies==0)
        {
            completionPercentage.text = "0%";
        }
        else
        {
            completionPercentage.text = ((totalZombies- zombiesLeft )/totalZombies )*100+ "%";
        }
        
        if(zombiesLeft == 0 && !(totalZombies == 0))
        {
            SceneManager.LoadScene("winScene");
        }

       
    }
}
