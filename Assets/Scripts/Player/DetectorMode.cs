using System;
using UnityEngine;

/// <summary>
/// Компонент отвечает за режим наблюдения за врагами
/// Поля:
/// -listEnemes: список имеющихся врагов на карте
/// -triggerHandler: при инициализации получает ссылку на обработчик триггеров
/// -EnemyWithinReach: враг находится в зоне поражения (событие используется в компоненте Player)
/// -NoEnemiesWithinReach: враг вышел из зоны поражения (событие используется в компоненте Player)
/// _isEnemyWithinReach: флаг что враг в зоне досягаемости
/// </summary>
public class DetectorMode : MonoBehaviour
{
    [SerializeField] public Enemy[] listEnemes;

    private TriggerHandler _triggerHandler;
    private bool _isEnemyWithinReach;

    public Action EnemyWithinReach;
    public Action NoEnemiesWithinReach;

    public void Init(TriggerHandler triggerHandler)
    {
        _triggerHandler = triggerHandler;
    }

    /// <summary>
    /// Поиск врагов в поле зрения, запускается когда персонаж встает на место наблюдения
    /// </summary>
    /// <param name="viewingRange">Дальность обзора на месте наблюдения</param>
    public void SearchInSight(float viewingRange)
    {
        int countEnemyWithinReach = 0;
        //Получаем расстояние обзора с вышки                        
        //В дальнейшем hitDistance может складываться не только из обзора с вышки а так же учитывать баффы, дебаффы, перки персонажа для увеличения или уменьшения площади поражения 
        foreach (var enemy in listEnemes)
        {
            if (enemy.IsDead == false)
            {
                //Получаем дистанцию до ближайщего врага
                float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);

                if (distanceToEnemy <= viewingRange)
                {
                    countEnemyWithinReach += 1;
                }
            }                   
        }

        if (countEnemyWithinReach > 0 && _isEnemyWithinReach == false)
        {            
            EnemyWithinReach?.Invoke();
            _isEnemyWithinReach = true;
        }
        else if(countEnemyWithinReach == 0 && _isEnemyWithinReach == true)
        {            
            NoEnemiesWithinReach?.Invoke();
            _isEnemyWithinReach = false;
        }           
    }

    private void OnEnable()
    {
        _triggerHandler.GotOverviewObservationTower += SearchInSight;
    }

    private void OnDisable()
    {
        _triggerHandler.GotOverviewObservationTower -= SearchInSight;
    }
}
