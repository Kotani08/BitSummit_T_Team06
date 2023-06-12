using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// NavMeshAgent�R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�A�^�b�`
[RequireComponent(typeof(NavMeshAgent))]
public class WayPointMove : MonoBehaviour
{
    // �o�R�|�C���g�̔z��
    [SerializeField] private Transform[] waypoints;
    // �e���x
    [SerializeField] private int Closeness; 
    
    // NavMeshAgent�R���|�[�l���g������ϐ�
    private NavMeshAgent navMeshAgent;
    // ���݂̖ړI�n(�z��v�f�ԍ�)
    private int currentWaypointIndex;
    // ����t���O(true�Ȃ珄�񂷂�)
    private bool patrolFlag;

    // Start is called before the first frame update
    void Start()
    {
        // navMeshAgent�ϐ���NavMeshAgent�R���|�[�l���g������
        navMeshAgent = GetComponent<NavMeshAgent>();
        // �ŏ��̖ړI�n��ݒ�
        navMeshAgent.SetDestination(waypoints[0].position);
        // ����t���O�ݒ�
        patrolFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        // ���񒆏���
        if(patrolFlag == true)
        {
            // �ړI�n�_�܂ł̋���(remainingDistance)���ړI�n�̎�O�܂ł̋���(stoppingDistance)�ȉ��ɂȂ�����
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                // �ړI�n�̗v�f�ԍ���1�����i�ő�l�𒴂���ꍇ�A0�ɖ߂�j
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                // �ړI�n�����̏ꏊ�ɐݒ�
                navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
        // �v���C���[�ɒǏ]���Ă���ꍇ
        else
        {

        }
    }

    // ����t���O��؂�ւ���
    void ChangePatrolFlag()
    {
        patrolFlag = !patrolFlag;
    }
}
