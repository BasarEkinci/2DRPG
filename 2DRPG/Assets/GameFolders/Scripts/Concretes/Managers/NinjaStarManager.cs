using System;
using System.Collections;
using System.Collections.Generic;
using TDRPG.Abstracts;
using TMPro;
using UnityEngine;

namespace TDRPG.Managers
{
    public class NinjaStarManager : SingeltonThisObject<NinjaStarManager>
    {
        private int ninjaStarBank;

        [SerializeField] private TMP_Text starText;

        private void Awake()
        {
            SingeltonThisGameObject(this);
        }

        private void Update()
        {
            starText.text = "x" + ninjaStarBank;
        }

        public void IncreaseStarAmount(int starCollected)
        {
            ninjaStarBank += starCollected;
        }
        
        public void DecreaseStarAmount(int starSpent)
        {
            ninjaStarBank -= starSpent;
        }
    }    
}


