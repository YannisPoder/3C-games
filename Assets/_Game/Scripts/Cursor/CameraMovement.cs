using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [Header("Dependances")]
    [SerializeField] Player _player;
    [SerializeField] Transform _target;
    [SerializeField] CursorInputController _cIP;
    [SerializeField] Camera _camera;
    [SerializeField] CinemachineCamera _cameraController;

    [Header("Conf")]
    [SerializeField] float _speed;
    [SerializeField] float _edgeSize;
    [SerializeField] float _playerEdgeScreen;

    bool _startMove;
    bool _outBorder;
    public Vector3 Direction { get; private set; }

    void Awake()
    {
        _startMove = true;
        _outBorder = false;
        _cIP.OnMoveCam += MoveUpdate;
        _cIP.OnMouseStop += MoveStop;
        _cIP.OnCenter += CenterCam;
    }

    void Update()
    {
        Direction = new Vector3(Direction.x, 0, Direction.z);
        OutOfScreen();
        Vector3 targetPos = _target.position;
        if (Direction != Vector3.zero)
        {           
            _target.Translate(Direction * Time.deltaTime * _speed);
        }
    }

    void OnDestroy()
    {
        _cIP.OnMoveCam -= MoveUpdate;
        _cIP.OnMouseStop -= MoveStop;
        _cIP.OnCenter -= CenterCam;
    }

    void MoveUpdate(InputAction.CallbackContext context)
    {        
        Direction = Vector3.zero;
        bool isMoving = false;
        if (context.control.device is Gamepad)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            Vector2 gamepadDir = context.ReadValue<Vector2>();
            Direction = new Vector3(gamepadDir.x, 0, gamepadDir.y);
            isMoving = true;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Vector2 mousePos = context.ReadValue<Vector2>();
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            if (mousePos.x < _edgeSize)
            {
                Direction += /*Vector3.left **/ -1 * _camera.transform.right;
                isMoving = true;
            }
            else if (mousePos.x > screenSize.x - _edgeSize)
            {
                Direction += /*Vector3.right*/ _camera.transform.right;
                isMoving = true;
            }
            else if (mousePos.y < _edgeSize)
            {
                Direction += /*Vector3.back*/ -1 * _camera.transform.forward;
                isMoving = true;
            }
            else if (mousePos.y > screenSize.y - _edgeSize)
            {
                Direction += /*Vector3.forward*/ _camera.transform.forward;
                isMoving = true;
            }
        }
        if (_startMove && isMoving)
            MoveCam();
    }

    void MoveStop(InputAction.CallbackContext context)
    {
        Direction = Vector3.zero;
    }

    void OutOfScreen()
    {
        Vector3 viewportPoint = _camera.WorldToViewportPoint(_player.transform.position);
        Vector2 screenPos = new Vector2(viewportPoint.x, viewportPoint.y);
        if (_outBorder)
        {
            _outBorder = false;
            Direction = Vector3.zero;
        }
        if (screenPos.x < _playerEdgeScreen)
        {
            Direction -= 1*_camera.transform.right;
            _outBorder = true;
        }            
        if (screenPos.y < _playerEdgeScreen)
        {
            Direction -= 1*_camera.transform.forward;
            _outBorder = true;
        }            
        if (screenPos.x  > 1 - _playerEdgeScreen)
        {
            Direction += 1 * _camera.transform.right;
            _outBorder = true;
        }
        if (screenPos.y > 1 - _playerEdgeScreen)
        {
            Direction += 1 * _camera.transform.forward;
            _outBorder = true;
        }        
        Direction = new Vector3(Direction.x, 0, Direction.z);
    }

    void CenterCam(InputAction.CallbackContext context)
    {
        _cameraController.Follow = _player.transform;
        _startMove = true;
    }

    void MoveCam()
    {
        _target.position = _player.transform.position;
        _cameraController.Follow = _target;
        _startMove = false;
    }
}
