using TDRPG.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TDRPG.PlayerScripts
{
    public class Experience : SingeltonThisObject<Experience>
    {
        [SerializeField] private Image expImage;
        [SerializeField] private TMP_Text levelText;

        private int currentLevel;
        private float currentExperience;
        private float expToNextLevel = 100;
        
        private void Awake()
        {
            SingeltonThisGameObject(this);
        }

        private  void Start()
        {
            expImage.fillAmount = currentExperience / expToNextLevel;
            currentLevel = 1;
        }

        private void Update()
        {
            expImage.fillAmount = currentExperience / expToNextLevel;
            levelText.text = currentLevel.ToString();
        }

        public void AddExperience(float experience)
        {
            currentExperience += experience;
            if(currentExperience >= expToNextLevel)
            {
                currentLevel += 1;
                expToNextLevel *= 1.7f;
                currentExperience = 0;
                PlayerHealth.Instance.CurrentHealth += 20;
                PlayerHealth.Instance.MaxHealth += 20;
            }
        }
    }    
}

