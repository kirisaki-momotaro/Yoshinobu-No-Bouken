using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalInstantiator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;



    public GameObject cryptonite;
    public GameObject rosium;
    public GameObject etherium;


    public GameObject tile;


    public int map_size_x;
    public int map_size_z;




    public bool changeSeed = false;

    private void Start()
    {



        for (int x = 0; x < map_size_x; x++)
        {
            for (int z = 0; z < map_size_z; z++)
            {
                int tile_size_x = (int)tile.transform.GetComponent<Renderer>().bounds.size.x;
                int tile_size_z = (int)tile.transform.GetComponent<Renderer>().bounds.size.z;

                Instantiate_Crystals(x * tile_size_x, z * tile_size_z);
            }
        }


    }


    public void Instantiate_Crystals(int x_pos, int z_pos)
    {


        for (int x = 0; x <= width; x += Random.Range(1, width / 5))
        {
            for (int y = 0; y <= width; y += Random.Range(1, height / 5))
            {
                float random_place = Random.value;
                if (random_place > .95f)
                {
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    GameObject crystal = Instantiate(cryptonite, pos, Quaternion.identity, transform);
                    
                    //enemy.GetComponent<enemy_controller>().health *= enemy_size;

                }
                if (random_place < .05f)
                {
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    GameObject crystal = Instantiate(rosium, pos, Quaternion.identity, transform);
                    
                    //enemy.GetComponent<enemy_controller>().health *= enemy_size;

                }
                if (random_place > .05f && random_place < .15f)
                {
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    GameObject crystal = Instantiate(etherium, pos, Quaternion.identity, transform);
                   
                    //enemy.GetComponent<enemy_controller>().health *= enemy_size;

                }




            }
        }
    }
}
