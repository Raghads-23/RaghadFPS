using UnityEngine;

public class ChaseState : BaseState
{
    public override void Enter() {}

    public override void Perform()
    {
        enemy.Agent.SetDestination(enemy.player.position);

        // فعل أنيميشن المشي
        enemy.animator.SetTrigger("IsWalking");
        enemy.animator.ResetTrigger("IsIdle");
    }

    public override void Exit() {}
}
