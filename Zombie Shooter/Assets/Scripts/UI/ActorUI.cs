using Scripts.Player;
using UnityEngine;

namespace Scripts.UI
{
    public class ActorUI : MonoBehaviour
    {
        public HpBar HpBar;

        private PlayerHealth _playerHealth;

        private void OnDestroy() => 
            _playerHealth.HealthChanged -= UpdateHpBar;

        public void Construct(PlayerHealth health)
        {
            _playerHealth = health;

            _playerHealth.HealthChanged += UpdateHpBar;
        }

        public void UpdateHpBar()
        {
            HpBar.SetValue(_playerHealth.Current, _playerHealth.Max);
        }
    }
}
