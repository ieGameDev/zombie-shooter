using Scripts.Data;
using Scripts.Infrastructure.Services.PersistentProgress;
using System;
using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerHealth : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private PlayerAnimator _playerAnimator;
        private State _state;

        public Action HealthChanged;

        public float CurrentHealth
        {
            get => _state.CurrentHP;
            set
            {
                if (_state.CurrentHP != value)
                {
                    _state.CurrentHP = value;
                    HealthChanged?.Invoke();
                }
            }
        }

        public float MaxHealth
        {
            get => _state.MaxHP;
            set => _state.MaxHP = value;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _state = progress.PlayerState;
            HealthChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.PlayerState.CurrentHP = CurrentHealth;
            progress.PlayerState.MaxHP = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (CurrentHealth <= 0)
                return;

            CurrentHealth -= damage;
            _playerAnimator.PlayHit();

            Debug.Log(CurrentHealth);
        }
    }
}
