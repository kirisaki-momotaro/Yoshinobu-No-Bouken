using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class level_generator : MonoBehaviour
{
    public NavMeshSurface surface;
    public int width = 10;
    public int height = 10;



    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public GameObject obstacle5;
    public GameObject obstacle6;
    public GameObject obstacle7;
    public GameObject obstacle8;
    public GameObject healer_flower;

    

    public GameObject tile;

    public int seed;
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

                GenerateLevel(x * tile_size_x, z * tile_size_z);
            }
        }

        surface.BuildNavMesh();
    }


    public void GenerateLevel(int x_pos, int z_pos)
    {
        Vector3 tile_pos = new Vector3(x_pos, -1.25f, z_pos);
        Instantiate(tile, tile_pos, Quaternion.identity, transform);

        for (int x = 0; x <= width; x += Random.Range(1, width / 5))
        {
            for (int y = 0; y <= width; y += Random.Range(1, height / 5))
            {
                float random_place = Random.value;
                if (random_place < .1f)
                {
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    Instantiate(healer_flower, pos, Quaternion.identity, transform);
                    //int flower_size = Random.Range(1, 3);
                    //healer_flower.transform.localScale = healer_flower.transform.localScale + new Vector3(flower_size, flower_size, flower_size);
                }

                if (random_place > .9f)
                {
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    Instantiate(obstacle1, pos, Quaternion.identity, transform);
                }

                if (random_place > .8f && random_place < .9f)
                {
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    Instantiate(obstacle2, pos, Quaternion.identity, transform);
                }
                if (random_place > .7f && random_place < .8f)
                {
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    Instantiate(obstacle3, pos, Quaternion.identity, transform);
                }
                if (random_place > .6f && random_place < .7f)
                {
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    Instantiate(obstacle4, pos, Quaternion.identity, transform);
                }
                if (random_place > .55f && random_place < .6f)
                {
                    Vector3 pos = new Vector3(x - width / 2f + x_pos, -2f, y - height / 2f + z_pos);
                    Instantiate(obstacle5, pos, Quaternion.identity, transform);
                }
                



            }
        }
    }


}