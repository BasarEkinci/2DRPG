using System;
using System.Collections;
using TDRPG.Abstracts;
using TDRPG.EnemyScripts;
using TDRPG.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TDRPG.PlayerScripts
{
    public class PlayerHealth : SingeltonThisObject<PlayerHealth>
    {

        private float maxHealth = 100f;
        private float currentHealth;
        [SerializeField] private Image healthBar;
        private Animator animator;
        private bool isImmune;

        public float CurrentHealth
        {
            get => currentHealth;

            set
            { currentHealth = value; }
        }

        public float MaxHealth
        {
            get => maxHealth;

            set { maxHealth = value; }
        }
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
            SingeltonThisGameObject(this);
        }

        private void Start()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {
            healthBar.fillAmount = currentHealth / maxHealth;
            
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy") && !isImmune)
            {
                currentHealth -= other.GetComponent<EnemyStats>().damage;
                SoundManager.Instance.PlaySound(1);
                StartCoroutine("Immunity");
                animator.SetTrigger("HitTrigger");

                if (currentHealth <= 0)
                {
                    Debug.Log("You're Dead");
                }
            }
        }

        IEnumerator Immunity()
        {
            isImmune = true;
            yield return new WaitForSecondsRealtime(1f);
            isImmune = false;
        }
    }    
}


