using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SG
{
    public class EnemyInventory : MonoBehaviour
    {

        EnemyWeaponSlotManager weaponSlotManager;

        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<EnemyWeaponSlotManager>();
            Debug.Log("trouvé");
        }

        private void Start()
        {
            
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon);
            //weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        }
    }
}
