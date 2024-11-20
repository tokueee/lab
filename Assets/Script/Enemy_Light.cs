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

    private Vector3 Enemy_Position; // �G�̏����ʒu

    //LightEnemy�̍��W�擾�p
    [SerializeField] private GameObject Lenemy;

    //�X�N���v�g�擾�p
    [SerializeField] private GameObject enemy2;
    [SerializeField] private EnemyControll econ;

    //�����v�Z��̑���p
    private float distans;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playercs = player.GetComponent<Player_Light>();
        econ = enemy2.GetComponent<EnemyControll>();
        Enemy_Position = Startpotision.transform.position;
        //  navMeshAgent.destination = Goal[destNum].position;
    }

    // Update is called once per frame
    void Update()
    {
        distans = Vector3.Distance(Lenemy.transform.position,player.transform.position);
        int inum = econ.DisNum(distans);//�����ɉ����ĕԂ��֐��Ăяo��
        //Debug.Log(inum);
        econ.Dtrans(inum);//�����ɉ����ăm�C�Y�̋�����ς���֐��Ăяo��

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

        //������ς���
        Vector3 DirectionToTarget = (targetPosition - transform.position).normalized;
        float DistanceToPlayer = DirectionToTarget.magnitude;
        DirectionToTarget = DirectionToTarget.normalized;

        Quaternion LookRotation = Quaternion.LookRotation(DirectionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5.0f); // ��]���x�𒲐�

        //transform.position += DirectionToTarget * Speed * Time.deltaTime;
    }
}


