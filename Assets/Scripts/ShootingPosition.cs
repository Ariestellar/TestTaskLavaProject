using UnityEngine;

/// <summary>
/// Компонент отвечает за обзорную вышку 
/// Имеет настраиваенмые поля:
/// viewRadius - разные вышки имеют разный уровень обзора
/// </summary>
public class ShootingPosition : MonoBehaviour
{
    [Range(0, 10)][SerializeField] private float viewRadius;    
    public float ViewRadius { get => viewRadius; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);        
    }

}
