using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControll : MonoBehaviour
{
    [SerializeField]
    [Tooltip("追いかける対象")]
    private GameObject player;
    private NavMeshAgent nevMeshAgent;

    [SerializeField]
    private float Enemy_Angle;

    [SerializeField]
    private float Enemy_View;

    private bool isChasing = false;

    [SerializeField]
    private Transform[] Goal;

    private int destNum = 0;

    [SerializeField] private GameObject Cnoi;//Script取得用
    [SerializeField] private GameObject enemy;//距離取得の為にエネミー取得
    [SerializeField] private CameraNoise noise;//Script取得用2
    private float dis;//距離計算後の代入用変数

    //ノイズの透過度の値
    private float lmax = 0.1f;
    private float lightmin_c = 0.08f;
    private float lmid = 0.06f;
    private float lmin = 0.04f;

    //距離用の変数
    private float cdist = 10.0f;
    private float mdist = 20.0f;
    private float fcdist = 30.0f;
    private float fdists = 40.0f;


    // Start is called before the first frame update
    void Start()
    {
        nevMeshAgent = GetComponent<NavMeshAgent>();
        nevMeshAgent.destination = Goal[destNum].position;
        noise = Cnoi.GetComponent<CameraNoise>();
        noise.setTrans(0.0f);//透過の初期化
        //Debug.Log(noise.getTrans());
    }

    //距離に応じて返す関数
    public int DisNum(float dist)
    {
        if (dist < cdist) return 0;
        if (dist < mdist) return 1;
        if (dist < fcdist) return 2;
        if (dist < fdists) return 3;
        return 4;
    }

    //距離に応じてノイズの強さを変える関数
    public void Dtrans(float distnum)
    {
        switch (distnum)
        {
            //disnumの値に応じて実行する
            case 0:
                noise.setTrans(lmax);
                noise.enabled = true; break;
            case 1:
                noise.setTrans(lightmin_c);
                noise.enabled = true; break;
            case 2:
                noise.setTrans(lmid);
                noise.enabled = true; break;
            case 3:
                noise.setTrans(lmin);
                noise.enabled = true; break;
            case 4:
                noise.setTrans(0.0f);
                noise.enabled = true; break;
        }
    }

    // Update is called once per frame
    void Update()
    { 
        CheckPlayer();
        dis = Vector3.Distance(enemy.transform.position,player.transform.position);
        //プレイヤーと敵の直線距離計算
        //Debug.Log(dis);
        int disnum = DisNum(dis);
        //Debug.Log(disnum);
        Dtrans(disnum);
        /*switch (disnum)
        {
            //disnumの値に応じて実行する
            case 0:
                noise.setTrans(lmax) ;
                noise.enabled = true; break;
            case 1:
                noise.setTrans(lightmin_c) ;
                noise.enabled = true; break;
            case 2: 
                noise.setTrans(lmid) ;
                noise.enabled = true; break;
            case 3:
                noise.setTrans(lmin) ;
                noise.enabled = true; break;
            case 4:
                noise.setTrans(0.0f);
                noise.enabled = true; break;
        }*/
        // Debug.Log(Enemy_Angle);
        // Debug.Log(Enemy_View);
        if (isChasing == true)
        {
            nevMeshAgent.destination = player.transform.position;
        }
        else
        {
            if (nevMeshAgent.remainingDistance < 0.5f) { Patrol(); }
        }
    }

    private void CheckPlayer()
    {
        Vector3 DirectionToPlayer = player.transform.position - transform.position;
        float DistanceToPlayer = DirectionToPlayer.magnitude;
        if (DistanceToPlayer <= Enemy_View)
        {
            //方向の正規化
            DirectionToPlayer = DirectionToPlayer.normalized;

            float AngleToPlayer = Vector3.Angle(transform.forward, DirectionToPlayer);

            if (AngleToPlayer <= Enemy_Angle / 2f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, DirectionToPlayer, out hit, Enemy_View))
                {
                    // Rayが当たった位置をデバッグログに表示
                    //Debug.Log("Ray hit position: " + hit.point);
                    //Debug.Log("Hit distance: " + hit.distance); // ヒットした距離を表示
                    if (hit.collider.gameObject == player)
                    {
                        isChasing = true; return;
                    }
                }
            }
        }
        else { isChasing = false; }
    }
    private void Patrol()
    {
        if (isChasing == false)
        {
            destNum += 1;
            if (destNum == 4)
            {
                destNum = 0;
            }
            nevMeshAgent.destination = Goal[destNum].position;
        }
    }
}
