using Scripts.Player;
using UnityEngine;

namespace Scripts.Services.Input
{
    public class DesktopMovementInput : MonoBehaviour
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

        private Vector3 _moveVector;
        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            _moveVector = new Vector3(UnityEngine.Input.GetAxis(Horizontal), 0, UnityEngine.Input.GetAxis(Vertical));
            _moveVector = Vector3.ClampMagnitude(_moveVector, 1f);

            _playerMovement.PlayerMove(_moveVector);
        }
    }
}