using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SG
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;
        DamageCollider zoneDamageCollider;
        private void Awake()
        {
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isleftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if (weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem,bool isLeft)
        {
            
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(weaponItem);
                LoadLeftWeaponDamageCollider();

            }
            else
            {
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
            }

            LoadZoneAttack();
        }

        #region Handle Weapon's Damage
        private void LoadLeftWeaponDamageCollider()
        {
            leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();

        }

        private void LoadRightWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();

        }

        public void OpenRightDamageCollider()
        {
            rightHandDamageCollider.EnableChangeCollider();
        }

        public void OpenLeftDamageCollider()
        {
            leftHandDamageCollider.EnableChangeCollider();
        }

        public void CloseLeftDamageCollider()
        {
            leftHandDamageCollider.DisableChangeCollider();
        }

        public void CloseRightDamageCollider()
        {
            rightHandDamageCollider.DisableChangeCollider();
        }


        #endregion


        private void LoadZoneAttack()
        {

            zoneDamageCollider = GetComponent<DamageCollider>();
        }

        public void OpenZoneDamageCollider()
        {
            zoneDamageCollider.EnableChangeCollider();
        }

        public void CloseZoneDamageCollider()
        {
            zoneDamageCollider.DisableChangeCollider();
        }
    }
}

