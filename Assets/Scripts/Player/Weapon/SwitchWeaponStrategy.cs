using UnityEngine;

namespace Scripts.Player.Weapon
{
    public class SwitchWeaponStrategy
    {
        private IWeaponStrategy _weaponStrategy;

        public SwitchWeaponStrategy(IWeaponStrategy strategy) =>
            _weaponStrategy = strategy;

        public void Shoot()
        {
            if (_weaponStrategy != null)
                _weaponStrategy.Fire();
            else
                Debug.Log("No weapon strategy set!");
        }
    }
}