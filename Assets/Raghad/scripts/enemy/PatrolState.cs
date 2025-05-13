using UnityEngine;

public class PatrolState : BaseState
{
    public int wayPointsIndex;
    public float waitTimer;

    public override void Enter()
    {
        // عمليات الدخول (إذا كانت هناك حاجة لعمليات عند الدخول لهذه الحالة)
    }

    public override void Perform()
    {
        PatrolCycle();
    }

    public override void Exit()
    {
        // عمليات الخروج (إذا كانت هناك حاجة لعمليات عند الخروج من هذه الحالة)
    }

    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer > 3)
            {
                if (wayPointsIndex < enemy.path.wayPoints.Count - 1)
                {
                    wayPointsIndex++;
                }
                else
                {
                    wayPointsIndex = 0;
                }

                enemy.Agent.SetDestination(enemy.path.wayPoints[wayPointsIndex].position);
                waitTimer = 0;

                // تفعيل الأنيميشن عند الحركة
                enemy.SetWalkAnimation(true);
            }
        }
        else
        {
            // العدو في حالة حركة
            enemy.SetWalkAnimation(true);
        }

        if (enemy.Agent.remainingDistance <= 0.2f && waitTimer <= 3)
        {
            // إذا توقف العدو عن الحركة
            enemy.SetWalkAnimation(false);
        }
    }
}
