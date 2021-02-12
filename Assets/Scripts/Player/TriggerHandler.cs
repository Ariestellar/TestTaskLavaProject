using System;
using UnityEngine;

///<summary>
/// Компонент обработчик тригерров
/// Обязан иметь Rigidbody и Collider для нахождения триггеров
/// Поля:
/// -BeingTriggerShootingPosition: нахождение в триггере ShootingPosition (событие используется в компоненте Player)
/// -ExitTriggerShootingPosition: выход из триггера ShootingPosition (событие используется в компоненте Player)
/// -GotOverviewObservationTower: получил обзор на башне (событие используется в компоненте DetectorMode)
/// </summary>
[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class TriggerHandler : MonoBehaviour
{
    public Action BeingTriggerShootingPosition;
    public Action ExitTriggerShootingPosition;
    public Action<float> GotOverviewObservationTower;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ShootingPosition>())
        {
            BeingTriggerShootingPosition?.Invoke();
            GotOverviewObservationTower?.Invoke(other.GetComponent<ShootingPosition>().ViewRadius);                              
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ShootingPosition>())
        {
            ExitTriggerShootingPosition?.Invoke();            
        }
    }
}
