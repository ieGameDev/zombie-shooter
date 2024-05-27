using UnityEngine;

namespace Scripts.Player.Weapon
{
    public class SwitchWeapon : MonoBehaviour
    {
        public WeaponType CurrentWeaponType = WeaponType.None;
        private SwitchWeaponStrategy _currentWeapon;

        [SerializeField] private Animator _animator;

        [SerializeField] private GameObject _pistol;
        [SerializeField] private GameObject _rifle;

        [SerializeField] private PistolStrategy _pistolStrategy;
        [SerializeField] private RifleStrategy _rifleStrategy;

        private void Start()
        {
            ChooseWeapon();
        }

        public void ChooseWeapon()
        {
            Debug.Log("Choosing weapon: " + CurrentWeaponType);

            if (CurrentWeaponType != WeaponType.None)
            {
                switch (CurrentWeaponType)
                {
                    case WeaponType.Pistol:
                        _currentWeapon = new SwitchWeaponStrategy(_pistolStrategy);

                        _animator.SetInteger("State", 1);

                        _rifle.SetActive(false);
                        _pistol.SetActive(true);

                        Debug.Log("Pistol");
                        break;
                    case WeaponType.Rifle:
                        _currentWeapon = new SwitchWeaponStrategy(_rifleStrategy);

                        _animator.SetInteger("State", 2);

                        _rifle.SetActive(true);
                        _pistol.SetActive(false);

                        Debug.Log("Rifle");
                        break;
                    default:
                        Debug.LogWarning("Unsupported weapon type: " + CurrentWeaponType);
                        break;
                }
            }
            else
            {
                _currentWeapon = null;
                _animator.SetInteger("State", 0);

                _rifle.SetActive(false);
                _pistol.SetActive(false);

                Debug.Log("None");
            }
        }

        public void Shoot()
        {
            Debug.Log("Current weapon type in Shoot(): " + CurrentWeaponType);


            if (_currentWeapon != null)
                _currentWeapon.Shoot();
            else
                Debug.Log("No Weapon");

        }
    }
}