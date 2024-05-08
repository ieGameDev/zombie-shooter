using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void AnimationDirection(Vector3 direction)
    {
        _animator.SetFloat("Vertical", direction.z * 1.5f);
        _animator.SetFloat("Horizontal", direction.x * 1.5f);
    }
}
