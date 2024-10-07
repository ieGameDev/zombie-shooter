using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerDeath : MonoBehaviour
    {
        public PlayerHealth PlayerHealth;
        public PlayerMovement PlayerMovement;
        public PlayerAnimator PlayerAnimator;

        //public GameObject DeathFX;
        private bool _isDead;

        private void Start() =>
            PlayerHealth.HealthChanged += HealthChanged;

        private void OnDestroy() =>
            PlayerHealth.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (!_isDead && PlayerHealth.CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;

            PlayerMovement.MoveSpeed = 0;
            PlayerMovement.RotateSpeed = 0;

            PlayerAnimator.PlayerDeath();

            //Instantiate(DeathFX, transform.position, Quaternion.identity);
        }
    }
}
