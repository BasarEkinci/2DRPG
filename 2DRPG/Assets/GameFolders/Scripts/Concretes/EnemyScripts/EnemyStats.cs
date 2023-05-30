using System.Collections;
using TDRPG.Managers;
using TDRPG.PlayerScripts;
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
        [SerializeField] private float expToGive;
        
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
            SoundManager.Instance.PlaySound(1);
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
                Experience.Instance.AddExperience(expToGive);
                Instantiate(deathEffect, transform.position, transform.rotation);
                SoundManager.Instance.PlaySound(4);
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


