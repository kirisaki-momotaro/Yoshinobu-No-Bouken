using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pagodaBehav : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player_controller>().health = collision.gameObject.GetComponent<player_controller>().maxHealth;


           
        }

    }
}
