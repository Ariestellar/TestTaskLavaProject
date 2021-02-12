using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Компонент отвечает за перемещение врага
/// Поля: 
/// -listTargetsMovement: список точек между которыми можно двигаться
/// -navMeshAgent: обязательное наличие NavMeshAgent на сущности
/// -currentTargetMovement: текущяя целевая позиция для движения
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _listTargetsMovement;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _currentTargetMovement;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();        
    }

    private void Start()
    {
        _currentTargetMovement = GetTargetMovement();
        _navMeshAgent.SetDestination(_currentTargetMovement);
    }

    private void Update()
    {
        if (transform.position == _navMeshAgent.pathEndPosition)
        {            
            _currentTargetMovement = GetTargetMovement();
            _navMeshAgent.SetDestination(_currentTargetMovement);
        }
    }

    private Vector3 GetTargetMovement()
    {
        return _listTargetsMovement[Random.Range(0, _listTargetsMovement.Length)].position;
    }
}
