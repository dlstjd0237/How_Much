using System;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "SO/Input/InputReader")]
public class InputReader : ScriptableObject, PlayerInput.IPlayerActions, PlayerInput.IUIActions
{
    public float XInput { get; private set; }
    public float YInput { get; private set; }
    public float XMouseInput { get; private set; }
    public float YMouseInput { get; private set; }
    private PlayerInput _playerInput;
    private bool _isOpenMap = false;

    #region KeyEvent

    public event Action OpenMapEvent;
    public event Action ClosedMapEvent;
    public event Action OnSprintEvent;
    public event Action OffSprintEvent;

    #endregion

    private void OnEnable()
    {
        if (_playerInput == null)
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.SetCallbacks(this);
            _playerInput.UI.SetCallbacks(this);
        }

        _playerInput.Player.Enable();
        _playerInput.UI.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 Input = context.ReadValue<Vector2>();
        XInput = Input.x;
        YInput = Input.y;
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        Vector2 mouseInput = context.ReadValue<Vector2>().normalized;
        XMouseInput = mouseInput.x;
        YMouseInput = mouseInput.y;
    }

    public void OnMap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_isOpenMap) //∏ ¿Ã ≤®¡Æ¿÷¥Ÿ∏È
            {
                _playerInput.Player.Disable();
                OpenMapEvent?.Invoke();
                _isOpenMap = !_isOpenMap;
            }
            else if (!_isOpenMap) // ∏ ¿Ã ƒ—¡Æ¿÷¥Ÿ∏È
            {
                _playerInput.Player.Enable();
                ClosedMapEvent?.Invoke();
                _isOpenMap = !_isOpenMap;
            }
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnSprintEvent?.Invoke();
        }
        else if (context.canceled)
        {
            OffSprintEvent?.Invoke();
        }

    }
}
