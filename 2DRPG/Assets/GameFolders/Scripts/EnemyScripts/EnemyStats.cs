using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDRPG.EnemyScripts
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private GameObject deathEffect;
        private float currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }    
}


