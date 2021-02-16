using UnityEngine;

[CreateAssetMenu]
public class IdleState : State
{
    [SerializeField] private InputHandler2 _inputHandler;
    [SerializeField] private State _isClick;

    public override void Init()
    {
        _inputHandler = Character.InputHandler;
        Character.Animator.SetBool("Idle", true);
    }

    public override void Run()
    {
        if (_inputHandler.CurrentPosition != Vector3.zero)
        {
            Character.SetState(_isClick);
            Character.Animator.SetBool("Idle", false);
        }
    }
}
