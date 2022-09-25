using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SG
{
    public class EnemyWeaponSlotManager : MonoBehaviour
    {

        WeaponHolderSlot rightHandSlot;
        WeaponHolderSlot leftHandSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;


        private void Awake()
        {
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isleftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else
                if (weaponSlot.isRightHandSlot)
                {
                rightHandSlot = weaponSlot;
                }
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem)
        {

            //if (isLeft)
            //{
            //    leftHandSlot.LoadWeaponModel(weaponItem);
            //    LoadLeftWeaponDamageCollider();

            //}
            //else
            //{
            rightHandSlot.LoadWeaponModel(weaponItem);
            Debug.Log("Load weapon");
            LoadRightWeaponDamageCollider();
            //}

            
        }

        //private void LoadLeftWeaponDamageCollider()
        //{
        //    leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();

        //}
        private void LoadRightWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();

        }

        public void OpenRightDamageCollider()
        {
            rightHandDamageCollider.EnableChangeCollider();
        }

        public void CloseRightDamageCollider()
        {
            rightHandDamageCollider.DisableChangeCollider();
        }
    }
}

