using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(RagdollController))]
public class Enemy : MonoBehaviour
{
    private EnemyMovement _enemyMovement;
    private RagdollController _ragdollCotroller;
    private bool _isDead;
    public bool IsDead { get => _isDead; }

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _ragdollCotroller = GetComponent<RagdollController>();
        _ragdollCotroller.Falling += Dead;
    }

    private void Dead()
    {
        _isDead = true;
        _enemyMovement.enabled = false; 
        this.enabled = false; 
        
    }

    private void OnDisable()
    {
        _ragdollCotroller.Falling -= Dead;
    }

}
