using UnityEngine;

/// <summary>
/// Компонент отвечает за работу сущности пули 
/// Поля:
/// -bulletInertiaMultiplier: множитель импульса добавляется для более эффектного падения персонажа
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _bulletInertiaMultiplier;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            if (collision.gameObject.GetComponentInParent<RagdollController>())
            {
                collision.gameObject.GetComponentInParent<RagdollController>().SetKinematic(false);                
                collision.gameObject.GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * _bulletInertiaMultiplier, ForceMode.Force);
            }            
            this.enabled = false;
        }
    }
}
