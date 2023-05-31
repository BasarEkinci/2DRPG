using TDRPG.Abstracts;
using TDRPG.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TDRPG.PlayerScripts
{
    public class Experience : SingeltonThisObject<Experience>
    {
        [SerializeField] private Image expImage;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private PlayerHealth playerHealth;

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
                SoundManager.Instance.PlaySound(2);
                expToNextLevel *= 1.7f;
                currentExperience = 0;
                playerHealth.CurrentHealth += 20;
                playerHealth.MaxHealth += 20;
            }
        }
    }    
}

