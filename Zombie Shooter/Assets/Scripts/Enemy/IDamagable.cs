using UnityEngine;

namespace Scripts.Enemy
{
    public interface IDamagable
    {
        void TakeDamage(float damage, Vector3 position, Vector3 direction);
    }
}
