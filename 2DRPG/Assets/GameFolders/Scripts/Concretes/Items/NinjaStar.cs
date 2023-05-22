using System;
using TDRPG.EnemyScripts;
using UnityEngine;

namespace TDRPG.Items
{
    public class NinjaStar : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
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
            else
            {
                Destroy(gameObject,5);
            }
        }
    }    
}


