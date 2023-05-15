using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TDRPG.EnemyScripts;
using UnityEngine;

namespace TDRPG.PlayerScripts
{
    public class PlayerHealth : MonoBehaviour
    {

        private float maxHealth = 100f;
        private float currentHealth;


        private void Start()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                currentHealth -= other.GetComponent<EnemyStats>().damage;

                if (currentHealth <= 0)
                {
                    Debug.Log("Öldün");
                }
            }
        }

    }    
}


