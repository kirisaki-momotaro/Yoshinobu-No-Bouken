using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached both to the Wall and the Mine.
// Its purpose is to demonstrate the function of Colliders and Triggers
public class KillPlayerLogic : MonoBehaviour
{
    private GameObject objectToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Remember that in order for Unity to call the OnTriggerEnter() function, the "Is Trigger" attribute in the object's collider
    // in the Inspector should be enabled. Else, the OnCollisionEnter() function will be called - if it is implemented.
    // In this lab example the Mine is set as a trigger (we want the Human to pass through it), so "Is Trigger" is enabled, while the Wall is not.
    // Thus, when an object (in this case the Human) enters the collider of the Mine, the OnTriggerEnter() function will be called.
    // Else, if the Human enters the collider of the Wall, the OnCollisionEnter() function will be called.

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Something entered my trigger");

        // We want to destroy the object entering the trigger, only if it is a Human.
        // We add first a tag "Player" to the Human from the Inspector.

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + ": The Player entered my trigger");


            //Destroy(other); // Not what we want. It will destroy the collider of the object that triggered (entered) THIS object.
            //Destroy(other.gameObject); //It will destroy the object that triggered (entered) THIS object.

            /////// ------ Destroy Player after 2 sec ------ ///////

            /// 1st METHOD: Using Destroy() function with the second argument for time delay
            Destroy(other.gameObject, 2f);  //It will destroy the object that triggered (entered) THIS object after 2 sec.

            /// 2nd METHOD: Create a method DestroyObject() and call it using Unity's Invoke() method //////
            //objectToDestroy = other.gameObject;
            //Invoke("DestroyObj", 2f); 
            //If time is set to 0, the method is invoked at the next Update cycle. In this case, it's better to call the function directly.
            //For better performance and maintability, use Coroutines instead.
            
            /// 3rd METHOD: Using a Coroutine
            //StartCoroutine(DestroyObj(other.gameObject, 2f));
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + ": The Player entered my trigger");

            Destroy(other.gameObject);
            
            //Destroy(other.gameObject, 2f);

            //objectToDestroy = other.gameObject;

            //Invoke("DestroyObj", 2f);

            //StartCoroutine(DestroyObj(other.gameObject, 2f));
        }
    }



    private void DestroyObj()
    {
        Destroy(objectToDestroy);
    }

    IEnumerator DestroyObj(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }
}
