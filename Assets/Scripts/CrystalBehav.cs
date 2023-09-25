using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBehav : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {

            if (gameObject.name == "Cryptonite(Clone)")
            {
                collision.gameObject.GetComponent<player_controller>().cryptoniteNum += 1;
            }

            if (gameObject.name == "Roseum(Clone)")
            {
                collision.gameObject.GetComponent<player_controller>().rosiumNum += 1;
            }

            if (gameObject.name == "Etherium(Clone)")
            {
                collision.gameObject.GetComponent<player_controller>().etheriumNum += 1;
            }
            Destroy(gameObject);
        }

    }
}
