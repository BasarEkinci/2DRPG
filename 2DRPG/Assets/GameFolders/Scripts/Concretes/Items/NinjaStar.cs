using System;
using TDRPG.EnemyScripts;
using TDRPG.Managers;
using TDRPG.PlayerScripts;
using UnityEngine;

namespace TDRPG.Items
{
    public class NinjaStar : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        [SerializeField] private ParticleSystem groundEffect;
        [SerializeField] private ParticleSystem bloodEffect;
        
        private PlayerController player;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            player = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            speed *= player.transform.localScale.x;
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward,10);
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyStats>().TakeDamage(damage);
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Ground"))
            {
                Instantiate(groundEffect, transform.position, transform.rotation);
                SoundManager.Instance.PlaySound(6);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject,5);
            }
        }
    }    
}


