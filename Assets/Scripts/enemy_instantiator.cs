using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy_instantiator : MonoBehaviour
{
    
    public int width = 10;
    public int height = 10;



    public GameObject zombie;

    public GameObject tile;

    public GameObject goalmeter;

   
    public int map_size_x;
    public int map_size_z;

    public int zombieNum;
    public int zombiesToKill;



    public bool changeSeed = false;

    private void Start()
    {
        zombieNum = 0;
        zombiesToKill = 0;

        for (int x = 0; x < map_size_x; x++)
        {
            for (int z = 0; z < map_size_z; z++)
            {
                int tile_size_x = (int)tile.transform.GetComponent<Renderer>().bounds.size.x;
                int tile_size_z = (int)tile.transform.GetComponent<Renderer>().bounds.size.z;

                Instantiate_enemies(x * tile_size_x, z * tile_size_z);
            }
        }

        zombiesToKill = (int)zombieNum * 70 / 100;
        Debug.Log(zombiesToKill);
        goalmeter.GetComponent<goalMeter>().totalZombies = zombiesToKill;
        goalmeter.GetComponent<goalMeter>().zombiesLeft = zombiesToKill;


    }


    public void Instantiate_enemies(int x_pos, int z_pos)
    {
       

        for (int x = 0; x <= width; x += Random.Range(1, width / 5))
        {
            for (int y = 0; y <= width; y += Random.Range(1, height / 5))
            {
                float random_place = Random.value;
                if (random_place > .95f)
                {
                    zombieNum++;
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    GameObject enemy = Instantiate(zombie, pos, Quaternion.identity, transform);
                    int enemy_size = Random.Range(1, 5);                    
                    enemy.transform.localScale = enemy.transform.localScale + new Vector3(enemy_size, enemy_size, enemy_size);
                    //enemy.GetComponent<enemy_controller>().health *= enemy_size;

                }

               


            }
        }
    }


}