using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class minion_controller : MonoBehaviour
{
    public Camera cam;


    float dist;
    public GameObject master;

    public NavMeshAgent agent;

    public GameObject zombie;


    public ParticleSystem shoot;
    ParticleSystem.EmissionModule em;
    //ParticleSystem.Particle gunParticle;

    //count zombie kills
    public GameObject goalMeter;

    //Life bar
    public GameObject timeDisplay;
    public Image timeAmount;

    

    //minion stats
    public int attack_power;
    public float attack_interval;
    public float next_attack;
    public bool attack_ready;
    public bool is_attacking;
    public bool chasing_zombie;
    public float maxTime;
    public float time;


    //selection image
    public GameObject selectionImage;

    //FOR UNIT SELECTION
    public bool isSelected;

    public float givenBattery=60;

    public Animator animator;

    public Vector3 destination;

    public int place_x;
    public int place_z;
    
    private void Start()
    {


       
        //enable particle system
        shoot = GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule _editableShape = shoot.shape;
       // _editableShape.position = transform.position + new Vector3(4.2f-0.4f, 0.15f+2.5f, -4);
        shoot.Play();
        em = shoot.emission;


        minion_init();



        place_x = Random.Range(-6, 6);
        place_z = Random.Range(-6, 6);
       
        master = GameObject.Find("YORINOBU_ISHIDA 1");
        goalMeter = GameObject.Find("goalMeter");
        cam = Camera.main;


    }


    // Update is called once per frame
    void Update()
    {
        //gunParticle.position = transform.position;
        time -= Time.deltaTime;
        Debug.Log(time);
        timeHandler();
        check_if_out_of_battery();
        selectionDispHandler();
        if (zombie != null)
        {
            dist = Vector3.Distance(zombie.transform.position, transform.position);
        }
        else
        {
            dist = float.PositiveInfinity;
            chasing_zombie = false;

        }
        if (chasing_zombie == true) {
            agent.SetDestination(zombie.transform.position);

            Vector3 direction = zombie.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.LookRotation(direction);
            
        }



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
                            Debug.Log("zombie found by minion");
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






        if (dist <= 10 && chasing_zombie == true)
        {
            agent.isStopped = true;


            // Rotate our transform a step closer to the target's.
            em.enabled = true;
            animator.SetBool("player_attacking", true);
            attack(zombie);
        }
        else if(!isSelected && !chasing_zombie)
        {
            em.enabled = false;
            agent.isStopped = false;
            animator.SetBool("player_attacking", false);
            destination = new Vector3(master.transform.position.x + place_x, master.transform.position.y, master.transform.position.z + place_z);
            agent.SetDestination(destination);
        }
        else
        {
            em.enabled = false;
            agent.isStopped = false;
            animator.SetBool("player_attacking", false);
            
        }




        


       

        
        // move agent

       


        

        if (agent.velocity.magnitude < 0.05f)
        {
            animator.SetBool("is_walking", false);
        }
        else
        {
            animator.SetBool("is_walking", true);
        }
    }
    public void minion_init()
    {
        isSelected = false;
        attack_power = 50;
        attack_interval = 1f;
        chasing_zombie = false;
        attack_ready = true;
        next_attack = 0;
        is_attacking = false;
       
        maxTime = givenBattery;
       
        time = maxTime;
       
    }

    public void timeHandler()
    {
        Camera camera = Camera.main;
        timeDisplay.transform.LookAt(timeDisplay.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
        float life = (float)time / maxTime;
        timeAmount.fillAmount = life;
        //Debug.Log(health / maxHealth);

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
            next_attack = Time.time + attack_interval;
            attack_ready = false;
            if (target.GetComponent<enemy_controller>().health < 0)
            {
                goalMeter.GetComponent<goalMeter>().zombiesLeft -= 1;
                master.GetComponent<player_controller>().money += target.GetComponent<enemy_controller>().money;
                master.GetComponent<player_controller>().zombieEssence += target.GetComponent<enemy_controller>().zombieEssence;
               
                Destroy(zombie);
                is_attacking = false;
                animator.SetBool("player_attacking", false);
            }



        }

    }
    public void check_if_out_of_battery()
    {
        if (time < 0)
        {
            Destroy(gameObject);
        }
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
        return "RX 3000 \n\n" + "Battery Time:" + time + "/" + maxTime + "\n" + "attack:" + attack_power + "\n\nPowerful long range attack machines that work on non rechargable battery";
    }
}
