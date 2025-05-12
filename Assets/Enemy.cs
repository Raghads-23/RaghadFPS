using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   public EnemyState _currentState;
   public EnemyStates enemyStates;

   public NavMeshAgent _agent;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        enemyStates = EnemyStates.Idle;
        StartCoroutine(StateController());
    }


    void StateChanger(EnemyStates newStates){
        switch(newStates)
        {
            case EnemyStates.Idle:
            {
                break;
            }

            case EnemyStates.Patrolliing:
            {
                break;
            }

            default:
            {
                break;
            }

        }
    }
    
    IEnumerator StateController()
    {
        while(enemyStates == EnemyStates.Idle){
           _currentState.ExecuteState(_agent);
           yield return null;
        }

        yield return null;
    }



    
}
