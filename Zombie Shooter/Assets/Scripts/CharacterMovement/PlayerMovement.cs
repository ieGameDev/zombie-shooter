using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Character Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [HideInInspector] public Vector3 velocityDirection;

    private CharacterController _characterController;
    private PlayerAnimator _playerAnimator;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void PlayerMove(Vector3 moveDirection)
    {
        _playerAnimator.AnimationDirection(moveDirection);

        Vector3 localMoveDirection = transform.TransformDirection(moveDirection);
        localMoveDirection *= _moveSpeed;

        _characterController.Move(localMoveDirection * Time.deltaTime);
    }

    public void PlayerRotate(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, _rotateSpeed * Time.deltaTime);
        }
    }
}
