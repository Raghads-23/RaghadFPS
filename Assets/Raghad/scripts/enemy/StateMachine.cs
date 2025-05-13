using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;

    public void Initialise(){
        patrolState = new PatrolState();
        ChangeState(patrolState);

    }


    void Update()
    {
        if(activeState != null)
            {

            activeState.Perform();
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
