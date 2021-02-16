using UnityEngine;

/// <summary>
/// Компонент фасад, отвечает за взаимодеиствие и работу отдельных компонентов-режимов игрока
/// (элементарная стейт машина)
/// Поля:
/// -inputHandler: обработчик ввода
/// -triggerHandler: обработчик триггеров
/// -detectorMode: компонент режима обнаружения
/// -shootingMode: компонент режима стрельбы
/// -moveMode: компонент режима движения
/// -animatorFunction: компонент управления анимациями (из стороннего Asseta "BasicBandit")
/// 
/// Обязан иметь AnimatorFunction
/// </summary>
[RequireComponent(typeof(ControllerAnimations))] 
public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private TriggerHandler _triggerHandler;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private PlayerParameterSettings _playerParameterSettings;

    [SerializeField] private DetectorMode _detectorMode;
    [SerializeField] private ShootingMode _shootingMode;
    [SerializeField] private MoveMode _moveMode;

    [SerializeField] private Animator _animatorIK;
    private ControllerAnimations _animatorFunction; 

    private void Awake()
    {
        _animatorFunction = GetComponent<ControllerAnimations>();

        //Инициализируем компоненты
        _moveMode.Init(_inputHandler, _playerParameterSettings.Speed);
        _shootingMode.Init(_inputHandler, _weapon, _animatorIK);        
        _detectorMode.Init(_triggerHandler);
        _weapon.Init((int)_playerParameterSettings.BulletThrustForce, _playerParameterSettings.RateFire);

        //Подписываемся на события необходимые для переключения режимов
        _detectorMode.EnemyWithinReach += EnableShootingMode;        
        _detectorMode.EnemyWithinReach += DisableMoveMode;       
        _detectorMode.EnemyWithinReach += _animatorFunction.Idle;
        _detectorMode.EnemyWithinReach += _animatorFunction.OnAiming;       

        _detectorMode.NoEnemiesWithinReach += DisableShootingMode;        
        _detectorMode.NoEnemiesWithinReach += _animatorFunction.OffAiming;        
        _detectorMode.NoEnemiesWithinReach += EnableMoveMode;

        _moveMode.ReachedDestination += _animatorFunction.Idle;
        _moveMode.StartMoving += _animatorFunction.Run;

        _triggerHandler.BeingTriggerShootingPosition += EnableDetectorMode;
        _triggerHandler.ExitTriggerShootingPosition += DisableDetectorMode;
    }

    private void Start()
    {
        EnableMoveMode();
    }

    private void EnableDetectorMode()
    {
        _detectorMode.enabled = true;
    }

    private void DisableDetectorMode()
    {
        _detectorMode.enabled = false;
    }

    private void EnableShootingMode()
    {
        _shootingMode.enabled = true;
    }

    private void DisableShootingMode()
    {                
        _shootingMode.enabled = false;
    }

    private void EnableMoveMode()
    {
        _moveMode.enabled = true;        
    }

    private void DisableMoveMode()
    {
        _moveMode.enabled = false;        
    }
}
