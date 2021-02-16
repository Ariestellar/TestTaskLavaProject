using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShootingState : State
{    
    public override void Init()
    {
        Character.RigShooting.weight = 1;        
        Character.Animator.SetBool("Idle", true);        
        Character.Animator.SetBool("Move", false);
        Character.NavMeshAgent.isStopped = true;
    }

    public override void Run()
    {
        
    }
}
