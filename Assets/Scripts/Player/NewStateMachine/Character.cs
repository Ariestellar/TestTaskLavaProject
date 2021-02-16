using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(NavMeshAgent), typeof(NavMeshAgent))] 
public class Character : MonoBehaviour
{
    [SerializeField] private InputHandler2 _inputHandler;
    [SerializeField] private ShootingPosition _shootingPosition;
    [SerializeField] private List<Enemy> _listEnemy;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Rig _rigShooting;    

    [SerializeField] private State _move;
    [SerializeField] private State _idle;
    [SerializeField] private State _detection;
    [SerializeField] private State _shooting;

    [SerializeField] private State _currentState;    

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rigShooting = GetComponentInChildren<Rig>();
        _rigShooting.weight = 0;
        _detection = Instantiate(_detection);
        _detection.Character = this;
        _detection.Init();
    }

    public InputHandler2 InputHandler { get => _inputHandler;}
    public NavMeshAgent NavMeshAgent { get => _navMeshAgent;}
    public Animator Animator { get => _animator;}
    public ShootingPosition ShootingPosition { get => _shootingPosition;}
    public List<Enemy> ListEnemy { get => _listEnemy;}
    public Rig RigShooting { get => _rigShooting;}

    private void Start()
    {
        SetState(_idle);
    }

    private void Update()
    {
        if (Vector3.Distance(_shootingPosition.transform.position, transform.position) <= 3)
        {            
            _detection.Run();
        }

        if (!_currentState.IsFinished)
        {
            _currentState.Run();
        }        
    }

    public void SetState(State state)
    {
        _currentState = Instantiate(state);
        _currentState.Character = this;
        _currentState.Init();
    }
}
