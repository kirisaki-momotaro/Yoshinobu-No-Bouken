using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    public GameObject HumanPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn a Human, when the "S" key is pressed.
        //if (Input.GetKey(KeyCode.S)) //GetKey returns true while the user holds down the key identified by name.
        if (Input.GetKeyDown(KeyCode.S))  // GetKeyDown returns 1 only for the one frame the Space key was pressed.
        // if(Input.GetButtonDown("Jump"))  // Spawn a Human, when the "Jump" button is pressed (for keyboard, this by default is set to "Space". See Edit->Project Settings -> Input Manager).
        {
            Spawn();
        }
    }

    void Spawn()
    {
        //Spawn a HumanPrefab instance at position 1,1,1 with rotation 0,0,0.
        //Instantiate(HumanPrefab, new Vector3(1, 1, 1), Quaternion.Euler(0, 0, 0));
        //Instantiate(HumanPrefab, Vector3.one, Quaternion.Euler(0, 0, 0)); // Alternative 

        //Spawn a HumanPrefab instance at the position of the Spawner empty Game Object where this script is attached to.
        //Instantiate(HumanPrefab, transform.position, transform.rotation);
    }
}
