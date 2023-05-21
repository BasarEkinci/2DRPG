using System;
using UnityEngine;

namespace TDRPG.Managers
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField] private float bank;

        public static CoinManager Instance;


        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
            
        }

        public void IncreaseMoney(int coinCollected)
        {
            bank += coinCollected;
        }

        public void DecreaseMoney(int coinSpent)
        {
            bank -= coinSpent;
        }
    }    
}


