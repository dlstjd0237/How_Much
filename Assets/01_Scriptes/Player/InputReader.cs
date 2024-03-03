using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "SO/Input/InputReader")]
public class InputReader : ScriptableObject, PlayerInput.IPlayerActions
{
    public float XInput { get; private set; }
    public float YInput { get; private set; }
    public float XMouseInput { get; private set; }
    public float YMouseInput { get; private set; }
    private PlayerInput _playerInput;

    private void OnEnable()
    {
        if (_playerInput == null)
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.SetCallbacks(this);
        }

        _playerInput.Player.Enable();
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
}
