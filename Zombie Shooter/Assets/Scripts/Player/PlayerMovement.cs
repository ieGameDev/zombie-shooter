using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Character Movement Settings")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [HideInInspector] public Vector3 velocityDirection;

        private CharacterController _characterController;
        private PlayerAnimator _playerAnimator;

        private Vector3 _moveDirection;
        private Vector3 _rotateDirection;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void Update()
        {
            _playerAnimator.AnimationDirection(_moveDirection, _rotateDirection);
        }

        public void PlayerMove(Vector3 moveDirection)
        {
            _moveDirection = moveDirection;

            velocityDirection.x = moveDirection.x * _moveSpeed;
            velocityDirection.z = moveDirection.z * _moveSpeed;

            velocityDirection += Physics.gravity;

            _characterController.Move(velocityDirection * Time.deltaTime);
        }

        public void PlayerRotate(Vector3 rotateDirection)
        {
            _rotateDirection = rotateDirection;

            if (Vector3.Angle(transform.forward, rotateDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, rotateDirection, _rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }
}