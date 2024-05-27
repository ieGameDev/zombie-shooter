using Scripts.Player.Weapon;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.Infrastructure.Services.Input
{
    public class MobileRotationInput : JoystickHandler
    {
        private SwitchWeapon _switchWeapon;

        private void Awake() => 
            _switchWeapon = FindObjectOfType<SwitchWeapon>();

        private void Update()
        {
            if (_inputVector.x != 0 || _inputVector.y != 0)
                _playerMovement.PlayerRotate(new Vector3(_inputVector.x, 0, _inputVector.y));
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (_switchWeapon != null)
                _switchWeapon.Shoot();
            else
                Debug.LogError("SwitchWeapon не назначен!");
        }
    }
}