using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimateAlongAgent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyAnimator _animator;
        private const float MinimalVelocity = 0.1f;

        private void Update()
        {
            if (ShouldMove())
                _animator.Run();
            else
                _animator.StopRunning();
        }

        private bool ShouldMove() =>
            _agent.velocity.magnitude > MinimalVelocity && _agent.remainingDistance > _agent.radius;
    }
}
