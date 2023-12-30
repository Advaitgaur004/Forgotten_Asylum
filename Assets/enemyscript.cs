using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enemyscript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;
    public ParticleSystem freezeCircle; // Reference to the Freeze Circle particle system

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

    private void Awake()
    {
        player = GameObject.FindWithTag("sampletarget").transform; // Use the tag "Player" for efficient player identification
        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        playerinsightrange = Physics.CheckSphere(transform.position, sightrange, WhatIsPlayer);
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, WhatIsPlayer);

        if (freezeCircle.isPlaying) // Check if the Freeze Circle particle system is playing
        {
            agent.enabled = true; // Enable the NavMeshAgent
            enemyAnimator.enabled = true; // Enable the Animator
        }
        else
        {
            agent.enabled = false; // Disable the NavMeshAgent
            enemyAnimator.enabled = false; // Disable the Animator
            return; // Exit the Update method if the Freeze Circle is not playing
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

    private void attackplayer()
    {
        // Implement your attack logic here
    }
}