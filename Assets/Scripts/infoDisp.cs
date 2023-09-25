using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class infoDisp : MonoBehaviour
{

    public TextMeshProUGUI info;

    public GameObject infoObject;

    public bool infoTargetChanged;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        infoTargetChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (infoTargetChanged)
        {          

            if (infoObject.tag == "Player")
            {
                info.text = infoObject.GetComponent<player_controller>().info();


            }
            if (infoObject.tag == "minion")
            {

                info.text = infoObject.GetComponent<minion_controller>().info();

            }
            if (infoObject.tag == "enemy")
            {

                info.text = infoObject.GetComponent<enemy_controller>().info();

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                infoObject = hit.transform.gameObject;
                

                if (infoObject.tag == "Player")
                {
                    
                    infoTargetChanged = true;


                }
                if (infoObject.tag == "minion")
                {

                    
                    infoTargetChanged = true;

                }
                if (infoObject.tag == "enemy")
                {

                    
                    infoTargetChanged = true;

                }




            }
        }

    }
}
