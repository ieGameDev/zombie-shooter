using UnityEngine;

public class RifleStrategy : IWeaponStrategy
{
    public void Fire()
    {
        Debug.Log("Выстрел из автомата");
    }
}
