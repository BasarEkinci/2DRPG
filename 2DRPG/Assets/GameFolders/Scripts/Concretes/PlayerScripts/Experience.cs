using System;
using TDRPG.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace TDRPG.PlayerScripts
{
    public class Experience : SingeltonThisObject<Experience>
    {
        [SerializeField] private Image expImage;
        private float currentExperience;
        private float expToNextLevel = 100;
        
        private void Awake()
        {
            SingeltonThisGameObject(this);
        }

        private  void Start()
        {
            expImage.fillAmount = currentExperience / expToNextLevel;
        }

        public void AddExperience(float experience)
        {
            currentExperience += experience;
            expImage.fillAmount = currentExperience / expToNextLevel;
            if(currentExperience >= expToNextLevel)
            {
                expToNextLevel *= 1.7f;
                currentExperience = 0;
            }

        }
    }    
}


