using TDRPG.Managers;
using UnityEngine;

namespace TDRPG.Items
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int coinAmount;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CoinManager.Instance.IncreaseMoney(coinAmount);
                Destroy(gameObject);
            }
        }
    }    
}


