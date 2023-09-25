using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy_controller : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent agent;

    public GameObject player;

    public Animator animator;

    public Vector3 destination;

    public int place_x;
    public int place_z;

    private float nextActionTime = 0.0f;
    public float period = 5f;


    //player stats
    public float maxHealth;
    public float health;
    public int attack_power;
    public float attack_interval;
    public float next_attack;
    public bool attack_ready;


    //Health bar
    public GameObject healthDisplay;
    public Image healthAmount;


    //in game transactions and materials
    public int money;
    public int zombieEssence;

    void Start()
    {
        zombie_init();
        place_x = Random.Range(-2, 2);
        place_z = Random.Range(-2, 2);
       
        agent.speed = 1f * Random.Range(1,5);
        player = GameObject.Find("YORINOBU_ISHIDA 1");
    }

    // Update is called once per frame
    void Update()
    {
        healthHandler();
        //check_if_dead();

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < 10)
        {
            agent.isStopped = false;
            destination = new Vector3(player.transform.position.x + place_x, player.transform.position.y, player.transform.position.z + place_z);
            agent.SetDestination(destination);

            Vector3 direction = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.LookRotation(direction);

            if (dist <= 6)
            {
                agent.isStopped=true;
                animator.SetBool("zombie_attacking", true);
                attack(player);
            }
            else
            {
                animator.SetBool("zombie_attacking", false);
            }

            
        }
        else if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            agent.isStopped = false;
            destination = transform.position + new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
            agent.SetDestination(destination);
        }
        
        
        

        if (agent.velocity.magnitude < 0.05f)
        {
            animator.SetBool("zombie_walking", false);
        }
        else
        {
            animator.SetBool("zombie_walking", true);
        }
    }
    public void zombie_init()
    {
        health = 500*transform.localScale.x;
        maxHealth = health;
        attack_power = 50;
        attack_interval = 1f;        
        attack_ready = true;
        next_attack = 0;
        money = Random.Range(100, 500);
        zombieEssence = 10 * (int)transform.localScale.x;
    }
    public void attack(GameObject target)
    {
        if (next_attack < Time.time)
        {
            attack_ready = true;
        }
        if (attack_ready)
        {

            target.GetComponent<player_controller>().health -= attack_power;
            next_attack = Time.time + attack_interval;
            attack_ready = false;
            

            Debug.Log("attacking");
            Debug.Log("remaining enemy life =");
            Debug.Log(target.GetComponent<enemy_controller>().health);
        }

    }
    public void check_if_dead()
    {
        if (health < 0)
        {

            this.gameObject.SetActive(false);
        }
    }
    
    public void healthHandler()
    {
        Camera camera = Camera.main;
        healthDisplay.transform.LookAt(healthDisplay.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
        float life= (float) health / maxHealth;
        healthAmount.fillAmount = life;
        //Debug.Log(health / maxHealth);

    }
    public string info()
    {
        return "Zombie \n\n" + "HP:" + health + "/" + maxHealth + "\n" + "attack:" + attack_power + "\n\n!!!DANGER!!!\n\nENEMY MUST BE ANIHILATED";
    }
}
