using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SG
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damCollider;
        public int currentWeaponDamage=25;

        private void Awake()
        {
            //Debug.Log(GetComponent<Collider>());
            damCollider=GetComponent<Collider>();
            damCollider.gameObject.SetActive(true);
            damCollider.isTrigger = true;
            damCollider.enabled = false;
        }

        public void EnableChangeCollider()
        {
            damCollider.enabled = true;
        }

        public void DisableChangeCollider()
        {
            damCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Player")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                Debug.Log(playerStats);
                if (playerStats != null)
                {
                    playerStats.TakeDamage(5);
                    
                }
            }

            if (collision.tag == "Ennemy")
            {
                EnemyStats ennemyStats = collision.GetComponent<EnemyStats>();

                if (ennemyStats != null)
                {
                    ennemyStats.TakeDamage(currentWeaponDamage);
                }
            }
        }
    }
}

