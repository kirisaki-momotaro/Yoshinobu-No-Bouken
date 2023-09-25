using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {   
        //Get NavMesh Agent Component
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    Vector3 destinaionPosition;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            //Ray has as started point the clicked position on screen and drirection the cameras facing direction
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Send a Ray
            //We get the results in "out hit"
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {   
                if(hit.transform.tag == "Plane")
                {   
                    if (navMeshAgent.isStopped)
                        navMeshAgent.isStopped = false;

                    //Get the position of ray's hit point
                    destinaionPosition = hit.point;
                    //Set new Destination for Agent
                    navMeshAgent.SetDestination(destinaionPosition);
                }
            }
        }
        //Agent stops when gets close enough to destination
        if(Mathf.Abs(navMeshAgent.transform.position.x - destinaionPosition.x) < 0.1)
        {
            navMeshAgent.isStopped = true;
        }

    }
}
