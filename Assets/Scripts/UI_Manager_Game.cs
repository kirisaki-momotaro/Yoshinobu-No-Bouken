using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_Game : MonoBehaviour
{
   // [SerializeField]
   //to instantiate
    public GameObject unitPrefab;
    public GameObject factoryPrefab;
    public GameObject photoPrefab;
    public GameObject pagodaPrefab;
    public GameObject anvilPrefab;

    public GameObject player;


    public Transform spawner;

    public List<GameObject> iconLoading = new List<GameObject>();

    public List<string> thingsToMake = new List<string>();

    public Button unitPrefabBut;
    public Button factoryPrefabBut;
    public Button photoPrefabBut;
    public Button pagodaPrefabBut;
    public Button anvilPrefabBut;

    public bool factorySpawned;
    public bool pagodaSpawned;

    public GameObject factory;
    public float factoryCost=20;
    public float factoryRosiumCost = 1;

    public float photoCost=10;
    public float photoEtheriumCost = 2;

    public float robotCost=100;

    public float pagodaCost = 100;
    public float pagodaCryptoCost = 3;

    public float anvilCost = 100;
    public float anvilRosiumCost = 2;
    public float anvilCryptoCost = 3;

    public int photoSpawnedNum = 0;

    public bool isBuilding;
    public int buildingCounter;

    public List<Vector3> instantiatePos=new List<Vector3>();
    public List<Quaternion> instantiateRot = new List<Quaternion>();

    private void Start()
    {
        isBuilding = false;


        unitPrefabBut.gameObject.SetActive(false); ;
        factoryPrefabBut.gameObject.SetActive(true); ;
        photoPrefabBut.gameObject.SetActive(false); ;
        anvilPrefabBut.gameObject.SetActive(true);
        factorySpawned=false;
        pagodaSpawned = false;

}



    public void factory_Spawner()
    {
        if (factorySpawned == false)
        {

            if (player.GetComponent<player_controller>().rosiumNum >= factoryRosiumCost)
            {
                if (player.GetComponent<player_controller>().zombieEssence >= factoryCost)
                {
                    player.GetComponent<player_controller>().zombieEssence -= (int)factoryCost;
                    player.GetComponent<player_controller>().rosiumNum -= (int)factoryRosiumCost;
                    
                    
                    factoryPrefabBut.gameObject.SetActive(false); ;
                    
                    if (!isBuilding)
                    {
                        buildingCounter = 0;

                        iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);

                        instantiatePos.Add(player.transform.position + new Vector3(1, 0, 2));
                        instantiateRot.Add(player.transform.rotation);

                        StartCoroutine("CalculateTime", "factory");
                        isBuilding = true;
                    }
                    else
                    {
                        if (buildingCounter <= 3)
                        {
                            buildingCounter++;
                            thingsToMake.Add("factory");
                            instantiatePos.Add(player.transform.position + new Vector3(1, 0, 2));
                            instantiateRot.Add(player.transform.rotation);
                            iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);
                        }
                    }
                }
            }
            
            

        }
        
    }
    public void anvil_Spawner()
    {


        if (player.GetComponent<player_controller>().rosiumNum >= anvilRosiumCost && player.GetComponent<player_controller>().cryptoniteNum >= anvilCryptoCost)
        {
            if (player.GetComponent<player_controller>().zombieEssence >= anvilCost)
            {
                player.GetComponent<player_controller>().zombieEssence -= (int)anvilCost;
                player.GetComponent<player_controller>().rosiumNum -= (int)anvilRosiumCost;
                player.GetComponent<player_controller>().cryptoniteNum -= (int)anvilCryptoCost;

                
                
                anvilPrefabBut.gameObject.SetActive(false); ;
                if (!isBuilding)
                {
                    buildingCounter = 0;

                    iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);
                    instantiatePos.Add(player.transform.position + new Vector3(1, 0, 2));
                    instantiateRot.Add(player.transform.rotation);


                    StartCoroutine("CalculateTime", "anvil");
                    isBuilding = true;
                }
                else
                {
                    if (buildingCounter <= 3)
                    {
                        buildingCounter++;
                        thingsToMake.Add("anvil");
                        instantiatePos.Add(player.transform.position + new Vector3(1, 0, 2));
                        instantiateRot.Add(player.transform.rotation);
                        iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);
                    }
                }
            }
        }
       
           


     

    }
    public void pagoda_Spawner()
    {
        if(player.GetComponent<player_controller>().cryptoniteNum >= pagodaCryptoCost){
            if (pagodaSpawned == false)
            {

                if (player.GetComponent<player_controller>().zombieEssence >= pagodaCost)
                {
                    player.GetComponent<player_controller>().cryptoniteNum -= (int)pagodaCryptoCost;
                    player.GetComponent<player_controller>().zombieEssence -= (int)pagodaCost;
                    pagodaPrefabBut.gameObject.SetActive(false);
                    if (!isBuilding)
                    {
                        buildingCounter = 0;

                        iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);
                        instantiatePos.Add(player.transform.position + new Vector3(1, 0, 2));
                        instantiateRot.Add(player.transform.rotation);


                        StartCoroutine("CalculateTime", "pagoda");
                        isBuilding = true;
                    }
                    else
                    {
                        if (buildingCounter <= 3)
                        {
                            buildingCounter++;
                            thingsToMake.Add("pagoda");
                            instantiatePos.Add(player.transform.position + new Vector3(1, 0, 2));
                            instantiateRot.Add(player.transform.rotation);
                            iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);
                        }
                    }
                    
                    
                    
                }


            }

        }
        

    }

    public void photo_Spawner()
    {

        if (player.GetComponent<player_controller>().etheriumNum >= photoEtheriumCost)
        {
            if (player.GetComponent<player_controller>().zombieEssence >= photoCost)
            {
                player.GetComponent<player_controller>().etheriumNum -= (int)photoEtheriumCost;
                player.GetComponent<player_controller>().zombieEssence -= (int)photoCost;
                if (!isBuilding)
                {
                    buildingCounter = 0;

                    iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);
                    instantiatePos.Add(player.transform.position + new Vector3(1, 0, 2));
                    instantiateRot.Add(player.transform.rotation);


                    StartCoroutine("CalculateTime", "photo");
                    isBuilding = true;
                }
                else
                {
                    if (buildingCounter <= 3)
                    {
                        buildingCounter++;
                        thingsToMake.Add("photo");
                        instantiatePos.Add(player.transform.position + new Vector3(1, 0, 2));
                        instantiateRot.Add(player.transform.rotation);
                        iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);
                    }
                }
                
            }
        }
            
            
    }

    public void Button_Spawner()
    {
        if (player.GetComponent<player_controller>().money >= robotCost)
        {
            player.GetComponent<player_controller>().money -= (int)robotCost;
            if (!isBuilding)
            {
                buildingCounter = 0;

                iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);


                
                StartCoroutine("CalculateTime","robo");
                isBuilding = true;
            }
            else
            {
                if (buildingCounter <= 3)
                {
                    buildingCounter++;
                    thingsToMake.Add("robo");
                    iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);
                }
            }
        }
            

    }

    public void ActiveBuilding()
    {
        if (buildingCounter >= 0)
        {
            string toMake = thingsToMake[0];
            thingsToMake.RemoveAt(0);
            StartCoroutine("CalculateTime",toMake);
        }
        else
        {
            isBuilding = false;
        }
    }

    public IEnumerator CalculateTime(string objectToCreate)
    {
        yield return new WaitForSeconds(1);
        iconLoading[0].GetComponentInChildren<Slider>().value = 1;
        yield return new WaitForSeconds(1);
        iconLoading[0].GetComponentInChildren<Slider>().value = 2;
        yield return new WaitForSeconds(1);
        iconLoading[0].GetComponentInChildren<Slider>().value = 3;
        yield return new WaitForSeconds(1);
        iconLoading[0].GetComponentInChildren<Slider>().value = 4;
        yield return new WaitForSeconds(1);
        iconLoading[0].GetComponentInChildren<Slider>().value = 5;


        Vector3 pos =new Vector3(0f,0f,0f);
        Quaternion rot = new Quaternion(0f, 0f, 0f,0f);
        if (objectToCreate != "robo")
        {
            pos = instantiatePos[0];
            rot = instantiateRot[0];
            instantiatePos.RemoveAt(0);

            
            instantiateRot.RemoveAt(0);
        }

        if (objectToCreate == "robo")
        {
            GameObject robo = Instantiate(unitPrefab, factory.transform.position + new Vector3(-1, 0, -2), factory.transform.rotation);
            robo.GetComponent<minion_controller>().givenBattery = 60 + 20 * photoSpawnedNum;
        }else if(objectToCreate == "photo")
        {
            
            Instantiate(photoPrefab,pos, rot);
            photoSpawnedNum++;
        }
        else if (objectToCreate == "pagoda")
        {
            Instantiate(pagodaPrefab, pos, rot);
            pagodaSpawned = true;
        }
        else if (objectToCreate == "anvil")
        {
            player.GetComponent<player_controller>().attack_power *= 2;
            Instantiate(anvilPrefab, pos, rot);
        }
        else if (objectToCreate == "factory")
        {
            factory = Instantiate(factoryPrefab, pos, rot);
            factorySpawned = true;
            unitPrefabBut.gameObject.SetActive(true); ;
            photoPrefabBut.gameObject.SetActive(true); ;
        }




        iconLoading[buildingCounter].SetActive(!iconLoading[buildingCounter].activeSelf);
        buildingCounter--;
        iconLoading[0].GetComponentInChildren<Slider>().value = 0;

        ActiveBuilding();
    }
}
