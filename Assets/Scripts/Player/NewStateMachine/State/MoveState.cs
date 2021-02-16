using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class MoveState : State
{
    [SerializeField] private State _reachedTarget;
    private NavMeshAgent _playerNavMeshAgent;   

    public override void Init()
    {
        _playerNavMeshAgent = Character.NavMeshAgent;
        SetMovePosition(Character.InputHandler.CurrentPosition);
        Character.Animator.SetBool("Move", true);
    }

    public override void Run()
    {        
        if (Character.transform.position == _playerNavMeshAgent.pathEndPosition)
        {
            Character.SetState(_reachedTarget);
            Character.Animator.SetBool("Move", false);
        }
    }

    private void SetMovePosition(Vector3 targetOfMovement)
    {
        _playerNavMeshAgent.SetDestination(targetOfMovement);        
    }
}
