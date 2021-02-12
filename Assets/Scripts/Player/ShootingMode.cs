using UnityEngine;

/// <summary>
/// Компонент отвечает за режим стрельбы
/// Поля:
/// -currentPositionTarget: текущая позиция указателя цели
/// -inputHandler: При инициализации получает ссылку на обработчик ввода 
/// </summary>
public class ShootingMode : MonoBehaviour
{
    //private Vector3 _positionArm;
    private Animator _animatorIK;
    private Vector3 _currentPositionArm;
    private InputHandler _inputHandler;
    private Weapon _weapon;

    /*private void Update()
    {
        _positionArm = _currentPositionArm; 
    }*/

    public void Init(InputHandler inputHandler, Weapon weapon, Animator animatorIK)
    {
        _inputHandler = inputHandler;
        _weapon = weapon;
        _animatorIK = animatorIK;
    }

    private void FireShot(Vector3 targetPosition)
    {        
        //_currentPositionArm = GetPositionArm(targetPosition);
        _weapon.StartShooting(targetPosition);       
    }

    private void OnEnable()
    {
        _currentPositionArm = new Vector3();        
        _inputHandler.ReceivedClickPosition += FireShot;
        _animatorIK.enabled = true;
    }

    private void OnDisable()
    {
        _animatorIK.enabled = false;
        _inputHandler.ReceivedClickPosition -= FireShot; 
    }

    private Vector3 GetPositionArm(Vector3 target)
    {        
        return target;
    }
}
