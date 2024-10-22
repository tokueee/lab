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
    private Transform[] Gaol;

    private int destNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        nevMeshAgent = GetComponent<NavMeshAgent>();
        nevMeshAgent.destination = Gaol[destNum].position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();
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
                    Debug.Log("Ray hit position: " + hit.point);
                    Debug.Log("Hit distance: " + hit.distance); // ヒットした距離を表示
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
            nevMeshAgent.destination = Gaol[destNum].position;
        }
    }
}
