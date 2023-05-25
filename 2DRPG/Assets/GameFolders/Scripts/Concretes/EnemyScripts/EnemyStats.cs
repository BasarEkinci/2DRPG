using System.Collections;
using UnityEngine;

namespace TDRPG.EnemyScripts
{
    public class EnemyStats : MonoBehaviour
    {
        [Header("Damage")]
        [SerializeField] private float maxHealth;
        [SerializeField] private float knockBackForceX;
        [SerializeField] private float knockBackForceY;
        
        [Header("Effects")]
        [SerializeField] private GameObject deathEffect;
        [SerializeField] private float effectTimer;
        [SerializeField] private ParticleSystem bloodEffect;

        [SerializeField] private Transform playerTransform;
        
        private Rigidbody2D rigidbody2D;
        private float currentHealth;
        private HitEffect hitEffect;

        public float damage = 10f;

        private void Awake()
        {
            hitEffect = GetComponent<HitEffect>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            currentHealth = maxHealth;
        }
        
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            
            
            if (playerTransform.position.x < transform.position.x)
            {
                rigidbody2D.AddForce(new Vector2(knockBackForceX,knockBackForceY),ForceMode2D.Force);    
            }
            else
            {
                rigidbody2D.AddForce(new Vector2(-knockBackForceX,knockBackForceY),ForceMode2D.Force);
            }
            
            GetComponent<SpriteRenderer>().material = hitEffect.hitMat;
            Instantiate(bloodEffect, transform.position, transform.rotation);
            StartCoroutine("BackToNormal");

            if (currentHealth <= 0)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        
        IEnumerator BackToNormal()
        {
            yield return new WaitForSeconds(effectTimer);
            GetComponent<SpriteRenderer>().material = hitEffect.baseMat;
        }
    }    
}


