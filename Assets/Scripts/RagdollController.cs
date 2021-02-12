using System;
using UnityEngine;

/// <summary>
/// Компонент отвечает за поведение "Ragdoll"
/// Обязан иметь Animator
/// </summary>
[RequireComponent(typeof(Animator))]
public class RagdollController : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _allRidgidbodys;
    private Animator _animator;
    public Action Falling;

    private void Awake()
    {
        //_allRidgidbodys = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponent<Animator>();        
        SetKinematic(true);
    }

    /// <summary>
    /// Включает и отключает кинематику рагдолла персонажа
    /// </summary>
    /// <param name="value">
    /// true - вкл
    /// false - откл
    /// </param>
    public void SetKinematic(bool value)
    {
        _animator.enabled = value;
        foreach (var rigidbody in _allRidgidbodys)
        {
            rigidbody.isKinematic = value;
        }

        if (value == false)
        {
            Falling?.Invoke();
        }        
    }
}
