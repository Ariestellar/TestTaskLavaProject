using System;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Компонент отвечает за режим передвижения
/// Поля:
/// -playerNavMeshAgent: обязан иметь на сущности
/// -inputHandler: при инициализации получает ссылку на обработчик ввода 
/// -ReachedDestination: сущность достигла точки назначения (событие используется в компоненте Player)
/// -ReachedDestination: сущность начала движение (событие используется в компоненте Player)
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class MoveMode : MonoBehaviour
{
    private InputHandler _inputHandler;
    private NavMeshAgent _playerNavMeshAgent;   

    public Action ReachedDestination;
    public Action StartMoving;
    

    private void Awake()
    {
        _playerNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (transform.position  == _playerNavMeshAgent.pathEndPosition)
        {
            ReachedDestination?.Invoke();            
        }        
    }

    public void Init(InputHandler inputHandler, int speed)
    {
        _inputHandler = inputHandler;
        _playerNavMeshAgent.speed = speed;
    }

    private void SetTargetPosition(Vector3 targetOfMovement)
    {
        _playerNavMeshAgent.SetDestination(targetOfMovement);
        StartMoving?.Invoke();
    }

    private void OnEnable()
    {        
        _inputHandler.ReceivedClickPosition += SetTargetPosition;
    }
    
    private void OnDisable()
    {
        _inputHandler.ReceivedClickPosition -= SetTargetPosition;                 
    }
}
