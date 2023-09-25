using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    public void Start()
    {
        cam = FindObjectOfType<Camera>();
        agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // GetMouseButtonDown(1) -> Right mouse click
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Set new Destination for Target
                agent.SetDestination(hit.point);
            }
        }
    }
}
