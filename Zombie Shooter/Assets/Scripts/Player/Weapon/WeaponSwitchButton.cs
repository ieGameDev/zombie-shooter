using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Player.Weapon
{
    public class WeaponSwitchButton : MonoBehaviour
    {
        public WeaponType WeaponType;
        private SwitchWeapon _switchWeapon;

        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);

            _switchWeapon = FindObjectOfType<SwitchWeapon>();
        }

        private void OnClick()
        {
            _switchWeapon.CurrentWeaponType = WeaponType;
            _switchWeapon.ChooseWeapon();
        }
    }
}