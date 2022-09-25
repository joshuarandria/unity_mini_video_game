using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SG
{
    public class PlayerAttacker : MonoBehaviour
    {
        AnimatorHandler animatorHandler;
        InputHandler inputHandler;
        public string lastAttack;

        
        private void Awake()
        {
            
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            inputHandler = GetComponent<InputHandler>();
        }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            /*if (inputHandler.comboFlag)
            {
                animatorHandler.anim.SetBool("canDoCombos", false);
                if (lastAttack == weapon.OH_Light_Attack_1)
                {*/
            animatorHandler.PlayerTargetAnimation(weapon.OH_Light_Attack_2, true);
            lastAttack = weapon.OH_Light_Attack_2;
            /*   }
           }*/

        }
        public void HandleLightAttack(WeaponItem weapon)
        {
            animatorHandler.PlayerTargetAnimation(weapon.OH_Light_Attack_1, true);
            lastAttack = weapon.OH_Light_Attack_1;
        }

        public void HandleHeavyAttack(WeaponItem weapon)
        {
            animatorHandler.PlayerTargetAnimation(weapon.OH_Heavy_Attack_1, true);
            lastAttack = weapon.OH_Heavy_Attack_1;
        }



        
    }
}

