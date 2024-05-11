using UnityEngine;

public enum WeaponType
{
    None,
    Pistol,
    Rifle
}

public class SwitchWeapon : MonoBehaviour
{
    public WeaponType CurrentWeaponType = WeaponType.None;
    private SwitchWeaponStrategy _currentWeapon;

    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _pistol;
    [SerializeField] private GameObject _rifle;

    void Start()
    {
        ChooseWeapon();
    }

    public void ChooseWeapon()
    {
        if (CurrentWeaponType != WeaponType.None)
        {
            switch (CurrentWeaponType)
            {
                case WeaponType.Pistol:
                    _currentWeapon = new SwitchWeaponStrategy(new PistolStrategy());
                    _animator.SetInteger("State", 1);

                    _rifle.SetActive(false);
                    _pistol.SetActive(true);

                    Debug.Log("Pistol");
                    break;
                case WeaponType.Rifle:
                    _currentWeapon = new SwitchWeaponStrategy(new RifleStrategy());
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
        if (_currentWeapon != null)
        {
            _currentWeapon.Shoot();
        }
        else
        {
            Debug.LogWarning("No weapon selected!");
        }
    }
}
