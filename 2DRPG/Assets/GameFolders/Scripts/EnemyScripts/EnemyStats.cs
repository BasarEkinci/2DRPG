using System.Collections;
using UnityEngine;

namespace TDRPG.EnemyScripts
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private GameObject deathEffect;
        [SerializeField] private float effectTimer;
        
        private float currentHealth;
        private HitEffect hitEffect;

        private void Awake()
        {
            hitEffect = GetComponent<HitEffect>();
        }

        private void Start()
        {
            currentHealth = maxHealth;
        }
        
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            GetComponent<SpriteRenderer>().material = hitEffect.hitMat;
            StartCoroutine("BackToNormal");

            if (currentHealth <= 0)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        IEnumerator BackToNormal()
        {
            yield return new WaitForSeconds(effectTimer);
            GetComponent<SpriteRenderer>().material = hitEffect.baseMat;
        }
    }    
}


