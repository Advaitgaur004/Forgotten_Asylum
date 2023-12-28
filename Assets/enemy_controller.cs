using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemy_controller : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;

    //patroling
    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointrange;

    //attacking
    public float timebetweenattack;
    bool alreadyattacked;

    //states
    public float sightrange, attackrange;
    public bool playerinsightrange, playerinattackrange;


    private void Awake()
    {
        player = GameObject.Find("capsule").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        playerinsightrange = Physics.CheckSphere(transform.position, sightrange, WhatIsPlayer);
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, WhatIsPlayer);

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
        float randomx = Random.Range(-walkpointrange,walkpointrange);

        walkpoint = new Vector3(transform.position.x + randomx,transform.position.y,transform.position.z + randomz);
        if (Physics.Raycast(walkpoint,-transform.up,2f,WhatIsGround))
            walkpointset =true;
        

    }


    private void chaseplayer()
    {
        agent.SetDestination(player.position);
    }

    private void attackplayer()
    {
        
    }

}
