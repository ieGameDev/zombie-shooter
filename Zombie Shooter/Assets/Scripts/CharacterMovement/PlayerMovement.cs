using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Character Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [HideInInspector] public Vector3 velocityDirection;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void PlayerMove(Vector3 moveDirection)
    {
        velocityDirection.x = moveDirection.x * _moveSpeed;
        velocityDirection.z = moveDirection.z * _moveSpeed;
        _characterController.Move(velocityDirection * Time.deltaTime);
    }

    public void PlayerRotate(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
