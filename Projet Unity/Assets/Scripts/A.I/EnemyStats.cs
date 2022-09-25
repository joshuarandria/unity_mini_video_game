using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SG
{
    public class EnemyStats : CharacterStats
    {
        

        //public HealthBar healthBar;

        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            //healthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            //healthBar.SetCurrentHealth(currentHealth);

            animator.Play("Damage_01");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Death");
                StartCoroutine(DelayedDead(animator.GetCurrentAnimatorStateInfo(0).length));
            }
        }

        IEnumerator DelayedDead(float delay)
        {
            yield return new WaitForSeconds(delay + 2);
            Destroy(gameObject);
        }

    }
}