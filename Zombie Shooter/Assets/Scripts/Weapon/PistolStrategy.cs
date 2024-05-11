using UnityEngine;

public class PistolStrategy : IWeaponStrategy
{
    public void Fire()
    {
        Debug.Log("Выстрел из пистолета");
    }
}
