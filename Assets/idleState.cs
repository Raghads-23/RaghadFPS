using UnityEngine;
using UnityEngine.AI;

public class idleState : EnemyState
{
    public Transform idlePose;

    public override void ExecuteState(NavMeshAgent agent)
    {
        base.ExecuteState(agent);

        agent.SetDestination(idlePose.position);
    }

    
}
