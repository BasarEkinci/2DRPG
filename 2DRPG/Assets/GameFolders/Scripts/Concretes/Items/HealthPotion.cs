using System;
using System.Collections;
using System.Collections.Generic;
using TDRPG.PlayerScripts;
using UnityEngine;

namespace TDRPG.Items
{
    public class HealthPotion : MonoBehaviour
    {
        [SerializeField] private float healthToGive;

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            
            if (playerHealth != null)
            {
                playerHealth.CurrentHealth += healthToGive;
                Destroy(gameObject);
                //to do: add effect after picking potion
            }
        }
    }    
}


