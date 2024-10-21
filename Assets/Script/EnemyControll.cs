using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControll : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�ǂ�������Ώ�")]
    private GameObject player;
    private NavMeshAgent nevMeshAgent;

    //  [SerializeField] private Transform rayOrigin; // ���C�𔭎˂���I�u�W�F�N�g�̈ʒu


    [SerializeField]
    private float Enemy_Angle;

    [SerializeField]
    private float Enemy_View;

    private bool isChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        nevMeshAgent = GetComponent<NavMeshAgent>();
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
    }

    private void CheckPlayer()
    {
        Vector3 DirectionToPlayer = player.transform.position - transform.position;
        float DistanceToPlayer = DirectionToPlayer.magnitude;
        if (DistanceToPlayer <= Enemy_View)
        {
            //�����̐��K��
            DirectionToPlayer = DirectionToPlayer.normalized;

            float AngleToPlayer = Vector3.Angle(transform.forward, DirectionToPlayer);

            if (AngleToPlayer <= Enemy_Angle / 2f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, DirectionToPlayer, out hit, Enemy_View))
                {
                    // Ray�����������ʒu���f�o�b�O���O�ɕ\��
                    Debug.Log("Ray hit position: " + hit.point);
                    Debug.Log("Hit distance: " + hit.distance); // �q�b�g����������\��
                    if (hit.collider.gameObject == player)
                    {
                        isChasing = true; return;
                    }
                }
            }
        }
        else { isChasing = false; }
    }
}
