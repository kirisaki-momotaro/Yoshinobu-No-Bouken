using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingFlower : MonoBehaviour
{
    
   
    void OnTriggerEnter(Collider collision)
    {
        float healAmount=500;
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Heal "+healAmount);
            if (collision.gameObject.GetComponent<player_controller>().health + healAmount > collision.gameObject.GetComponent<player_controller>().maxHealth)
            {
                collision.gameObject.GetComponent<player_controller>().health += collision.gameObject.GetComponent<player_controller>().maxHealth - collision.gameObject.GetComponent<player_controller>().health;
            }
            else
            {
                collision.gameObject.GetComponent<player_controller>().health += healAmount;
            }

            Destroy(gameObject);
        }
        
    }
    }
