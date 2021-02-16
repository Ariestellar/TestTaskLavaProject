using System;
using UnityEngine;

/// <summary>
/// Компонент отвечает за пользовательский ввод с камеры
/// Поля:
/// -сamera: обязан иметь на сущности
/// -ReceivedClickPosition: полученна позиция клика (событие используется в MoveMode, ShootingMode)
/// -ButtonReleased: кнопка мыши отпущенна (событие используется в MoveMode, ShootingMode)
/// </summary>
[RequireComponent(typeof(Camera))]
public class InputHandler2 : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Vector3 _currentPosition;

    public Vector3 CurrentPosition { get => _currentPosition; set => _currentPosition = value; }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        LaunchRay();
    }

    private void LaunchRay()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                _currentPosition = hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _currentPosition = new Vector3();
        }
    }
}
