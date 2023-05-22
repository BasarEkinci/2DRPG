using System;
using System.Collections;
using System.Collections.Generic;
using TDRPG.Managers;
using UnityEngine;

namespace TDRPG.Items
{
    public class CollectableNinjaStar : MonoBehaviour
    {
        [SerializeField] private int amount;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                NinjaStarManager.Instance.IncreaseStarAmount(amount);
                Destroy(gameObject);
            }
        }
    }    
}

