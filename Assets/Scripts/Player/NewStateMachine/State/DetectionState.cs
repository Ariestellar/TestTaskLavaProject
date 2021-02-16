using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DetectionState : State
{
    [SerializeField] private State _enemiesWithinReach;
    [SerializeField] private State _enemiesOutOfRange;
    private List<Enemy> _listEnemy;    
    private float _viewingRange;

    public override void Init()
    {
        _viewingRange = Character.ShootingPosition.ViewRadius;
        _listEnemy = Character.ListEnemy;
    }

    public override void Run()
    {
        SearchInSight(_viewingRange);
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
        foreach (var enemy in _listEnemy)
        {
            if (enemy.IsDead == false)
            {
                //Получаем дистанцию до ближайщего врага
                float distanceToEnemy = Vector3.Distance(enemy.transform.position, Character.transform.position);

                if (distanceToEnemy <= viewingRange)
                {
                    countEnemyWithinReach += 1;
                }
            }
        }

        if (countEnemyWithinReach > 0)
        {
            Character.SetState(_enemiesWithinReach);
        }
        else if (countEnemyWithinReach == 0 )
        {
            Character.SetState(_enemiesOutOfRange);
        }
    }
}
