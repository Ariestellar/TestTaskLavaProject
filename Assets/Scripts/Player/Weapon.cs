using System.Collections;
using UnityEngine;

/// <summary>
/// Компонент отвечает за стрельбу
/// Поля:
/// -tempBullet: ссылка на префаб пули
/// -bulletThrustForce: сила выстрела, задается при инициализации
/// -rateFire: скорость стрельбы, время между спавном пули (1сек / на количество выстрелов) устанавливаается приинициализации
/// -timeLeft: время пройденное с момента выстрела (для контроля скорости стрельбы)
/// -direction: направление оружия
/// </summary>
public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _tempBullet;
    [SerializeField] private Transform _arm;
    private int _bulletThrustForce;
    private float _rateFire; 
    private float _timeLeft;
    private Vector3 _direction;

    private void Update()
    {
        _arm.position = new Vector3(_direction.x * 0.1f + transform.position.x , transform.position.y, _direction.z * 0.1f + transform.position.z);
    }

    public void Init(int bulletThrustForce, float rateFire)
    {
        _bulletThrustForce = bulletThrustForce;
        _rateFire = 1/rateFire;
    }    
    
    public void StartShooting(Vector3 target)
    {        
        _direction = GetDirectionShoot(target);        
        if (IsRangeFiring(_direction))
        {
            if (_timeLeft == 0)
            {
                StartCoroutine(Firing());
            }
        }        
    }

    private IEnumerator Firing()
    {
        CreateBullet();
        while (_timeLeft <= _rateFire)
        {
            _timeLeft += Time.deltaTime;            
            yield return null;
        }
        _timeLeft = 0;
    }

    private void CreateBullet()
    {
        var newBullet = Instantiate(_tempBullet);
        newBullet.transform.position = this.transform.position;        
        newBullet.GetComponent<Rigidbody>().AddForce(_direction * _bulletThrustForce, ForceMode.Acceleration);
    }

    private Vector3 GetDirectionShoot(Vector3 currentTarget)
    {
        var heading = currentTarget - this.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        return direction;
    }

    private bool IsRangeFiring(Vector3 directionTarget)
    {
        if (Vector3.Dot(Vector3.forward, directionTarget) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }
}
