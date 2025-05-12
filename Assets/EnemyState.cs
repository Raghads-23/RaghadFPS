using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates{
      Idle,
      Patrolliing
}

public class EnemyState : MonoBehaviour
{
    
    public virtual void ExecuteState(NavMeshAgent agent)
    {
        Debug.Log("");
    }
}
