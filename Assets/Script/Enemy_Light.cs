using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;
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

    /*
    //LightEnemyの座標取得用
    [SerializeField] private GameObject Lenemy;

    //スクリプト取得用
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject Cnoise2;//Script取得用
    [SerializeField] private CameraNoise noises;

    //距離計算後の代入用
    private float distans;

    //ノイズの透過度の値
    private float lmax = 0.1f;
    private float lightmin_c = 0.08f;
    private float lmid = 0.06f;
    private float lmin = 0.04f;

    //距離用の変数
    private float cdists = 10.0f;
    private float mdists = 20.0f;
    private float fcdists = 30.0f;
    private float fdists2 = 40.0f;

    //距離に応じて返す関数
    private int DisNum2(float dist)
    {
        if (dist < cdists) return 0;
        if (dist < mdists) return 1;
        if (dist < fcdists) return 2;
        if (dist < fdists2) return 3;
        return 4;
    }

    //距離に応じてノイズの強さを変える関数
    private void Dtrans2(float distnum)
    {

        switch (distnum)
        {
            //disnumの値に応じて実行する
            case 0:
                noises.SecondsetTrans(lmax);
                noises.enabled = true; break;
            case 1:
                noises.SecondsetTrans(lightmin_c);
                noises.enabled = true; break;
            case 2:
                noises.SecondsetTrans(lmid);
                noises.enabled = true; break;
            case 3:
                noises.SecondsetTrans(lmin);
                noises.enabled = true; break;
            case 4:
                noises.SecondsetTrans(0.0f);
                noises.enabled = true; break;
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playercs = player.GetComponent<Player_Light>();
        //noises = Cnoise2.GetComponent<CameraNoise>();
        Enemy_Position = Startpotision.transform.position;
        //  navMeshAgent.destination = Goal[destNum].position;
    }

    // Update is called once per frame
    void Update()
    {
        /*distans = Vector3.Distance(Lenemy.transform.position,player.transform.position);
        int inum = DisNum2(distans);//距離に応じて返す関数呼び出し
        //Debug.Log(inum);
        Dtrans2(inum);//距離に応じてノイズの強さを変える関数呼び出し
        */
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


