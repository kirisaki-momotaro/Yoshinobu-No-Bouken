using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player_controller : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    public GameObject zombie;
    //count zombie kills
    public GameObject goalMeter;


    public Animator animator;

    public bool chasing_zombie;


    //player stats
    public float maxHealth;
    public float health;
    public int attack_power;
    public float attack_interval;
    public float next_attack;
    public bool attack_ready;
    public bool is_attacking;
    float dist;

    //Health bar
    public GameObject healthDisplay;
    public Image healthAmount;

    //in game transactions and materials
    public int money;
    public int zombieEssence;

    public TextMeshProUGUI moneyDisplay;

    //selection image
    public GameObject selectionImage;

    //FOR UNIT SELECTION
    public bool isSelected;

    //ores
    public int cryptoniteNum;
    public int rosiumNum;
    public int etheriumNum;


    private void Start()
    {
        player_init();
    }
    // Update is called once per frame
    void Update()
    {
        check_if_dead();
        healthHandler();
        updateMoney();
        selectionDispHandler();

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (isSelected == true)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag == "enemy")
                        {
                            zombie = hit.transform.gameObject;
                            chasing_zombie = true;
                            Debug.Log("zombie found");
                            //agent.SetDestination(zombie.transform.position);

                        }
                        else
                        {
                            chasing_zombie = false;
                        }
                        // move agent
                        agent.SetDestination(hit.point);

                    }
                }
            }
        }
        
       


        
        //zombie = GameObject.Find("My_Zombie(Clone)");
        if (zombie != null) {
            dist = Vector3.Distance(zombie.transform.position, transform.position);
        }
        else
        {
            dist = float.PositiveInfinity;
        }
        



        if (chasing_zombie == true) {
            agent.SetDestination(zombie.transform.position);

            Vector3 direction = zombie.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.LookRotation(direction);
           
        }
          



        
        if (agent.velocity.magnitude < 0.05f)
        {
            animator.SetBool("is_walking", false);
        }
        else
        {
            animator.SetBool("is_walking", true);
        }



        

        if (dist < 5 && chasing_zombie)
            {
                agent.isStopped = true;
            //Debug.Log(dist);

            // Rotate our transform a step closer to the target's.
            animator.SetBool("player_attacking", true);
            
            attack(zombie);
            
           
            
                
            }           
        
        else
        {
            agent.isStopped = false;
            animator.SetBool("player_attacking", false);
        }

    }
    public void player_init()
    {
        isSelected = true;
        health = 1000;
        maxHealth=health;
        attack_power = 100;
        attack_interval = 1f;
        chasing_zombie = false;
        attack_ready = true;
        next_attack = 0;
        is_attacking=false;
        money = 0;
        zombieEssence = 0;
        cryptoniteNum = 0;
        rosiumNum = 0;
        etheriumNum = 0;
}
    public void attack(GameObject target)
    {
        if (next_attack < Time.time)
        {
            attack_ready = true;
        }
        if (attack_ready)
        {
           
            target.GetComponent<enemy_controller>().health -= attack_power;
            next_attack= Time.time + attack_interval;
            attack_ready = false;
            if (target.GetComponent<enemy_controller>().health<0)
            {
                goalMeter.GetComponent<goalMeter>().zombiesLeft -= 1;
                money += target.GetComponent<enemy_controller>().money;
                zombieEssence+= target.GetComponent<enemy_controller>().zombieEssence;
                Debug.Log(money+"G added");
                Debug.Log(zombieEssence+" zombie essence" );
                Destroy(zombie);
                is_attacking = false;
                animator.SetBool("player_attacking", false);
            }
            
           
            Debug.Log(target.GetComponent<enemy_controller>().health);
        }

    }


    public void healthHandler()
    {
        Camera camera = Camera.main;
        healthDisplay.transform.LookAt(healthDisplay.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
        float life = (float)health / maxHealth;
        healthAmount.fillAmount = life;
        //Debug.Log(health / maxHealth);

    }

    public void check_if_dead()
    {
        if (health < 0)
        {
            SceneManager.LoadScene("gameOver");
            Destroy(gameObject);
        }
    }
    public void updateMoney()
    {
        moneyDisplay.text = money + " 円   " + zombieEssence + " 魂";
    }

    public void selectionDispHandler()
    {
        if (isSelected)
        {
            selectionImage.SetActive(true);
        }
        else
        {
            selectionImage.SetActive(false);
        }
    }
    public string info()
    {
        return "NOBUNAGA ISHIDA \n\n" +"HP:"+health+"/"+ maxHealth +"\n"+"attack:"+ attack_power+"\n\ncryptonite:"+cryptoniteNum+ "\nrosium:"+ rosiumNum +"\netherium:"+ etheriumNum;
    }

}


