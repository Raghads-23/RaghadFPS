using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private Animator animator; // مرجع للـ Animator

    public NavMeshAgent Agent { get => agent; }
    public Path path;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // ربط الـ Animator
        stateMachine.Initialise();
    }

    public void SetWalkAnimation(bool isWalking)
    {
        if (isWalking)
        {
            animator.SetTrigger("IsWalking"); // تفعيل التريغر الخاص بالمشي
            animator.ResetTrigger("IsIdle"); // إيقاف التريغر الخاص بالوقوف
        }
        else
        {
            animator.SetTrigger("IsIdle"); // تفعيل التريغر الخاص بالوقوف
            animator.ResetTrigger("IsWalking"); // إيقاف التريغر الخاص بالمشي
        }
    }
}
