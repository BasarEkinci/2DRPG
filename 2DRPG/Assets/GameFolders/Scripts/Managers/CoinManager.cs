using System;
using TMPro;
using UnityEngine;

namespace TDRPG.Managers
{
    public class CoinManager : MonoBehaviour
    { 

        public static CoinManager Instance;

        [SerializeField] private TMP_Text coinText;
        
        private float bank;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
            
        }

        private void Update()
        {
            coinText.text = bank.ToString("0");
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


