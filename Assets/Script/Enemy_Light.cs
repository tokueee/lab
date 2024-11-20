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

    private Vector3 Enemy_Position; // 敵の初期位置

    //LightEnemyの座標取得用
    [SerializeField] private GameObject Lenemy;

    //スクリプト取得用
    [SerializeField] private GameObject enemy2;
    [SerializeField] private EnemyControll econ;

    //距離計算後の代入用
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
        int inum = econ.DisNum(distans);//距離に応じて返す関数呼び出し
        //Debug.Log(inum);
        econ.Dtrans(inum);//距離に応じてノイズの強さを変える関数呼び出し

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

        //方向を変える
        Vector3 DirectionToTarget = (targetPosition - transform.position).normalized;
        float DistanceToPlayer = DirectionToTarget.magnitude;
        DirectionToTarget = DirectionToTarget.normalized;

        Quaternion LookRotation = Quaternion.LookRotation(DirectionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5.0f); // 回転速度を調整

        //transform.position += DirectionToTarget * Speed * Time.deltaTime;
    }
}


