using UnityEngine;

namespace Scripts.Player.Weapon
{
    public class RifleStrategy : MonoBehaviour, IWeaponStrategy
    {        
        public void Fire()
        {
            Debug.Log("Выстрел из автомата");
        }        
    }
}