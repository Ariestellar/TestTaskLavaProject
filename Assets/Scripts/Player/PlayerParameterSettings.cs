using UnityEngine;

[CreateAssetMenu]
public class PlayerParameterSettings : ScriptableObject
{
    [Header("Сила пули")]
    [SerializeField] private BulletThrustForce _bulletThrustForce;
    [Header("Скорость персонажа")]
    [SerializeField] private int _speed;
    [Header("Скорость стрельбы (в выстрелах в секунду)")]
    [SerializeField] private float _rateFire;

    public int Speed { get => _speed;}
    public float RateFire { get => _rateFire;}
    internal BulletThrustForce BulletThrustForce { get => _bulletThrustForce;}
}

public enum BulletThrustForce
{ 
    Low = 300,
    Mid = 1000,
    Hight = 3000
}
