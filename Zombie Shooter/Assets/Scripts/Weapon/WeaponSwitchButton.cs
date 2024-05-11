using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitchButton : MonoBehaviour
{
    public WeaponType WeaponType;
    [SerializeField] private SwitchWeapon _switchWeapon;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        _switchWeapon.CurrentWeaponType = WeaponType;
        _switchWeapon.ChooseWeapon();
    }
}
