using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Dependances")]
    [SerializeField] Player _player;
    [SerializeField] Camera _camera;
    [SerializeField] PlayerInputController _pIC;
    [SerializeField] Animator _animator;

    [Header("Conf")]
    [SerializeField] float _speed;
    
    Vector3 _direction;
    Vector3 _mousePos;

    public Vector3 Direction { get;private set; }

    void Awake()
    {        
        _pIC.OnMove += MoveUpdate;
        _pIC.OnMoveStop += MoveStop;
        _pIC.OnMouseMove += RotateUpdate;
    }

    private void OnDestroy()
    {
        _pIC.OnMove -= MoveUpdate;
        _pIC.OnMoveStop -= MoveStop;
        _pIC.OnMouseMove -= RotateUpdate;
    }

    void Update()
    {
        if (_direction != Vector3.zero)
        {
            _player.transform.Translate(_direction * Time.deltaTime * _speed, Space.World);
        }
        if (_mousePos != null)
            _player.transform.LookAt(_mousePos);
        _animator.SetBool("IsMove", _direction != Vector3.zero);
    }

    void MoveUpdate(InputAction.CallbackContext move)
    {
        Vector3 dir = move.ReadValue<Vector2>();
        _direction = _camera.transform.forward * dir.y + _camera.transform.right * dir.x;
        _direction.y = 0;        
    }

    void MoveStop(InputAction.CallbackContext move)
    {
        _direction = Vector2.zero;
    }

    void RotateUpdate(InputAction.CallbackContext rotate)
    {
        if (rotate.control.device is Gamepad)
        {
            Vector2 pos = rotate.ReadValue<Vector2>();
            pos = pos * 100;
            if (pos.x == 0 && pos.y == 0) return;
            _mousePos = new Vector3(transform.position.x + pos.x, transform.position.y, transform.position.z + pos.y);
        }
        else
        {
            Ray ray = _camera.ScreenPointToRay(rotate.ReadValue<Vector2>());
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                _mousePos = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
            }
        }            
    }
}