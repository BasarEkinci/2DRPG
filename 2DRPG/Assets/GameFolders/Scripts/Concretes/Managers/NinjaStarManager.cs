using TDRPG.Abstracts;
using TMPro;
using UnityEngine;

namespace TDRPG.Managers
{
    public class NinjaStarManager : SingeltonThisObject<NinjaStarManager>
    {
        public int NinjaStarBank { get; set; }

        [SerializeField] private TMP_Text starText;

        private void Awake()
        {
            SingeltonThisGameObject(this);
        }
        
        
        private void Update()
        {
            starText.text = "x" + NinjaStarBank;
        }

        public void IncreaseStarAmount(int starCollected)
        {
            NinjaStarBank += starCollected;
            int starAmount = Mathf.Clamp(NinjaStarBank, 0,10);
            NinjaStarBank = starAmount;
        }
        
        public void DecreaseStarAmount(int starSpent)
        {
            NinjaStarBank -= starSpent;
        }
    }    
}


