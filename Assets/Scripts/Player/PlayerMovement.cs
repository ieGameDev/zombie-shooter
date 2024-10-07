using Scripts.Data;
using Scripts.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour, ISavedProgress
    {
        [Header("Character Movement Settings")]
        public float MoveSpeed;
        public float RotateSpeed;
        [HideInInspector] public Vector3 velocityDirection;

        [SerializeField] private CharacterController _characterController;
        private PlayerAnimator _playerAnimator;

        private Vector3 _moveDirection;
        private Vector3 _rotateDirection;

        private void Start()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void Update()
        {
            _playerAnimator.Move(_moveDirection, _rotateDirection);
        }

        public void PlayerMove(Vector3 moveDirection)
        {
            _moveDirection = moveDirection;

            velocityDirection.x = moveDirection.x * MoveSpeed;
            velocityDirection.z = moveDirection.z * MoveSpeed;

            velocityDirection += Physics.gravity;

            _characterController.Move(velocityDirection * Time.deltaTime);
        }

        public void PlayerRotate(Vector3 rotateDirection)
        {
            _rotateDirection = rotateDirection;

            if (Vector3.Angle(transform.forward, rotateDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, rotateDirection, RotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }

        public void UpdateProgress(PlayerProgress progress) =>
            progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentLevel() == progress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;

                if (savedPosition != null)
                    Warp(savedPosition);
            }
        }

        private void Warp(Vector3Data savedPosition)
        {
            _characterController.enabled = false;
            transform.position = savedPosition.AsUnityVector().AddY(_characterController.height);
            _characterController.enabled = true;
        }

        private static string CurrentLevel() =>
            SceneManager.GetActiveScene().name;
    }
}