using UnityEngine;

public class MobileRotation : JoystickHandler
{
    [SerializeField] private PlayerMovement _playerMovement;

    private void Update()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
        {
            _playerMovement.PlayerRotate(new Vector3(_inputVector.x, 0, _inputVector.y));
        }
    }
}
