using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SG
{
    public class PlayerStats : CharacterStats
    {
        
        public HealthBar healthBar;

        AnimatorHandler animatorHandler;
        Animator animator;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            animator = GetComponentInChildren<Animator>();

        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayerTargetAnimation("Damage_01",true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayerTargetAnimation("Death", true);
                StartCoroutine(DelayedDead(animator.GetCurrentAnimatorStateInfo(0).length));
            }
        }

        IEnumerator DelayedDead(float delay)
        {
            yield return new WaitForSeconds(delay + 2);
            Destroy(gameObject);
            Debug.Log("Game Over, Try Again");
            SceneManager.LoadScene("MainMenu");
        }

        public void CurePlayer()
        {
            currentHealth = maxHealth;
            healthBar.SetCurrentHealth(currentHealth);
        }
        
    }
}

