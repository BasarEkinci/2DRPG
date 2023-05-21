using System;
using TDRPG.Abstracts;
using TMPro;
using UnityEngine;

namespace TDRPG.Managers
{
    public class CoinManager : SingeltonThisObject<CoinManager>
    { 
        

        [SerializeField] private TMP_Text coinText;
        
        private int coinBank;

        private void Awake()
        {
            SingeltonThisGameObject(this);
        }

        private void Update()
        {
            coinText.text = coinBank.ToString("0");
        }

        public void IncreaseMoney(int coinCollected)
        {
            coinBank += coinCollected;
        }

        public void DecreaseMoney(int coinSpent)
        {
            coinBank -= coinSpent;
        }
        
    }    
}


