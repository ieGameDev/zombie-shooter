using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitchButton : MonoBehaviour
{
    public WeaponType WeaponType;
    private SwitchWeapon _switchWeapon;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        _switchWeapon = FindObjectOfType<SwitchWeapon>();
    }

    void OnClick()
    {
        _switchWeapon.CurrentWeaponType = WeaponType;
        _switchWeapon.ChooseWeapon();
    }
}
