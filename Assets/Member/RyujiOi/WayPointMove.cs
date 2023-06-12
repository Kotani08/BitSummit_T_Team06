using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// NavMeshAgentコンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(NavMeshAgent))]
public class WayPointMove : MonoBehaviour
{
    // 経由ポイントの配列
    [SerializeField] private Transform[] waypoints;
    // 親密度
    [SerializeField] private int Closeness; 
    
    // NavMeshAgentコンポーネントを入れる変数
    private NavMeshAgent navMeshAgent;
    // 現在の目的地(配列要素番号)
    private int currentWaypointIndex;
    // 巡回フラグ(trueなら巡回する)
    private bool patrolFlag;

    // Start is called before the first frame update
    void Start()
    {
        // navMeshAgent変数にNavMeshAgentコンポーネントを入れる
        navMeshAgent = GetComponent<NavMeshAgent>();
        // 最初の目的地を設定
        navMeshAgent.SetDestination(waypoints[0].position);
        // 巡回フラグ設定
        patrolFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 巡回中処理
        if(patrolFlag == true)
        {
            // 目的地点までの距離(remainingDistance)が目的地の手前までの距離(stoppingDistance)以下になったら
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                // 目的地の要素番号を1増加（最大値を超える場合、0に戻る）
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                // 目的地を次の場所に設定
                navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
        // プレイヤーに追従している場合
        else
        {

        }
    }

    // 巡回フラグを切り替える
    void ChangePatrolFlag()
    {
        patrolFlag = !patrolFlag;
    }
}
