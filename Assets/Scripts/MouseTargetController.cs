using UnityEngine;

public class MouseTargetController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // GetMouseButtonDown(0) -> left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Set new Destination for Target
                transform.position = hit.point;
            }
        }
    }
}
