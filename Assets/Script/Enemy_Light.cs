using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_Light : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Player playercs;

    [SerializeField]
    private Transform Startpotision;

    [SerializeField]
    private float Speed;

    private NavMeshAgent navMeshAgent;

    private Vector3 Enemy_Position; // ìGÇÃèâä˙à íu

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playercs = player.GetComponent<Player>();
        Enemy_Position = Startpotision.transform.position;
        //  navMeshAgent.destination = Goal[destNum].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playercs.Lightcheck())
        {
            // navMeshAgent.isStopped = false;
            navMeshAgent.destination = player.transform.position;
        }
        else
        {
            // navMeshAgent.isStopped = true;
            navMeshAgent.speed = Speed;
            navMeshAgent.destination = Startpotision.position;
        }
    }
}

