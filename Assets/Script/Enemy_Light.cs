using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_Light : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Player_Light playercs;

    [SerializeField]
    private Transform Startpotision;

    [SerializeField]
    private float Speed;

    private NavMeshAgent navMeshAgent;

    private Vector3 targetPosition;

    private Vector3 Enemy_Position; // ìGÇÃèâä˙à íu

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playercs = player.GetComponent<Player_Light>();
        Enemy_Position = Startpotision.transform.position;
        //  navMeshAgent.destination = Goal[destNum].position;
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshAgent.speed = Speed;
        // MoveTarget();
        if (playercs.Lightcheck())
        {     
          // DirectionToPosition = DirectionToPosition.normalized;
            // navMeshAgent.isStopped = false;
            navMeshAgent.destination = player.transform.position;
        }
        else
        {
            // navMeshAgent.isStopped = true;

            navMeshAgent.destination = Startpotision.position;
        }
    }
    private void MoveTarget()
    {

        //ï˚å¸ÇïœÇ¶ÇÈ
        Vector3 DirectionToTarget = (targetPosition - transform.position).normalized;
        float DistanceToPlayer = DirectionToTarget.magnitude;
        DirectionToTarget = DirectionToTarget.normalized;

        Quaternion LookRotation = Quaternion.LookRotation(DirectionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5.0f); // âÒì]ë¨ìxÇí≤êÆ

        //transform.position += DirectionToTarget * Speed * Time.deltaTime;
    }
}


