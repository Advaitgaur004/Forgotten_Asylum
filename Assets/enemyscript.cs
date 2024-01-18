using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enemyscript : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float currentHealth;
    public HealthBar healthBar;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;
    // public ParticleSystem freezeCircle; // Reference to the Freeze Circle particle system

    private float timer = 0.0f;
    // patroling
    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointrange;

    // attacking
    public float timebetweenattack;
    bool alreadyattacked;

    // states
    public float sightrange, attackrange;
    public bool playerinsightrange, playerinattackrange;

    // animation
    public Animator enemyAnimator; // Reference to the Animator component for animation control

    public BoxCollider boxCollider; // Reference to the BoxCollider component for collision detection
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Awake()
    {
        player = GameObject.FindWithTag("MainCamera").transform; // Use the tag "Player" for efficient player identification
        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        // boxCollider = GetComponentInChildren<BoxCollider>();
    }

    private void Update()
    {
        playerinsightrange = Physics.CheckSphere(transform.position, sightrange, WhatIsPlayer);
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, WhatIsPlayer);

        if (timer > 2.0f)
        {
            agent.enabled = true; // Enable the NavMeshAgent
            enemyAnimator.enabled = true; // Enable the Animator
        }
        else
        {
            agent.enabled = false; // Disable the NavMeshAgent
            enemyAnimator.enabled = false; // Disable the Animator
            timer += Time.deltaTime;
        }

        if (!playerinsightrange && !playerinattackrange) patroling();
        if (playerinsightrange && !playerinattackrange) chaseplayer();
        if (playerinsightrange && playerinattackrange) attackplayer();
    }

    private void patroling()
    {
        if (!walkpointset) searchwalkpoint();

        if (walkpointset)
        {
            agent.SetDestination(walkpoint);
        }

        Vector3 distancetowalkpoint = transform.position - walkpoint;
        if (distancetowalkpoint.magnitude < 1f)
            walkpointset = false;
    }

    private void searchwalkpoint()
    {
        float randomz = Random.Range(-walkpointrange, walkpointrange);
        float randomx = Random.Range(-walkpointrange, walkpointrange);

        walkpoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomz);
        if (Physics.Raycast(walkpoint, -transform.up, 2f, WhatIsGround))
            walkpointset = true;
    }

    private void chaseplayer()
    {
        agent.SetDestination(player.position);
    }

    float i = 0.0f;
    private void attackplayer()
    {
        print("Hi");
        enemyAnimator.SetTrigger("Attack");
        if (i == 10)
        {
            TakeDamage(10);
            print("hi");
            i = 0;
        }
        i++;
        agent.SetDestination(transform.position);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}