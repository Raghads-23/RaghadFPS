using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public Enemy enemy;

    public BaseState activeState;
    public PatrolState patrolState;
    public ChaseState chaseState;

    public void Initialise(){
        enemy = GetComponent<Enemy>();

        patrolState = new PatrolState();
        chaseState = new ChaseState();
        ChangeState(patrolState);

    }


    void Update()
{
    if (activeState != null)
    {
        activeState.Perform();
    }

    float distanceToPlayer = Vector3.Distance(enemy.player.position, transform.position);

    if (distanceToPlayer <= enemy.chaseRange && !enemy.playerInSafeZone)
    {
        ChangeState(chaseState);
    }
    else if (distanceToPlayer > enemy.chaseRange || enemy.playerInSafeZone)
    {
        ChangeState(patrolState);
    }
}


    public void ChangeState(BaseState newState){


// قبل مانغير الستيت نتأكد انه فاضيه
        if(activeState != null)
            {

            activeState.Exit();
            }

// بعدين نخزنه 
        activeState = newState;

// بعدين نبدا الستيت الجديدة
        if(activeState != null)
            {
                activeState.stateMachine = this;
                activeState.enemy = GetComponent<Enemy>();
                activeState.Enter();
            }



   }
}
