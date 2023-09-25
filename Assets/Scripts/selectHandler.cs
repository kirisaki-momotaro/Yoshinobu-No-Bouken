using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectHandler : MonoBehaviour
{
    public GameObject selectedObject;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Player")
                    {
                        selectedObject = hit.transform.gameObject;
                        if (selectedObject.GetComponent<player_controller>().isSelected)
                        {
                            selectedObject.GetComponent<player_controller>().isSelected = false;
                        }
                        else
                        {
                            selectedObject.GetComponent<player_controller>().isSelected = true;
                        }
                        

                    }
                    else if(hit.transform.tag == "minion")
                    {
                        selectedObject = hit.transform.gameObject;
                        if (selectedObject.GetComponent<minion_controller>().isSelected)
                        {
                            selectedObject.GetComponent<minion_controller>().isSelected = false;
                        }
                        else
                        {
                            selectedObject.GetComponent<minion_controller>().isSelected = true;
                        }
                    }
                    

                }
            }
        }
    }
}
