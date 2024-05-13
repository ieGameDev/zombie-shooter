using UnityEngine;

namespace Scripts.Services.Input
{
    public class MobileMovementInput : JoystickHandler
    {
        private void Update()
        {
            if (_inputVector.x != 0 || _inputVector.y != 0)
                _playerMovement.PlayerMove(new Vector3(_inputVector.x, 0, _inputVector.y));
        }
    }
}