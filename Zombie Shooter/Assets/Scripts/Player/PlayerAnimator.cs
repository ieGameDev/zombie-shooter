using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";

    private static readonly int IsMoving = Animator.StringToHash("Run");
    private static readonly int Hit = Animator.StringToHash("Hit");

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector3 moveDirection, Vector3 rotateDirection)
    {
        ChangeDirection(moveDirection, rotateDirection);
        Run(moveDirection);
    }

    public void PlayHit() =>
            _animator.SetTrigger(Hit);

    private void Run(Vector3 moveDirection)
    {
        bool isMoving = moveDirection.x != 0 || moveDirection.z != 0;
        _animator.SetBool(IsMoving, isMoving);
    }

    private void ChangeDirection(Vector3 moveDirection, Vector3 rotateDirection)
    {
        float forwardAngle = Vector3.SignedAngle(Vector3.forward, moveDirection, Vector3.up);
        float rotationAngle = Vector3.SignedAngle(Vector3.forward, rotateDirection, Vector3.up);

        if (forwardAngle < -180f)
            forwardAngle += 360f;
        if (rotationAngle < -180f)
            rotationAngle += 360f;

        float vertical = Mathf.Cos(Mathf.Deg2Rad * (rotationAngle - forwardAngle));
        float horizontal = Mathf.Sin(Mathf.Deg2Rad * (rotationAngle - forwardAngle));

        _animator.SetFloat(Vertical, vertical * 1.5f);
        _animator.SetFloat(Horizontal, horizontal * 1.5f);
    }
}
