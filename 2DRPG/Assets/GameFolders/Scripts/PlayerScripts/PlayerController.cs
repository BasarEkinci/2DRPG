using System;
using System.Collections;
using TDRPG.EnemyScripts;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDRPG.PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        private float movementDirection;
        
        private Rigidbody2D rb;
        private Animator animator;

        private bool isFacingRight = true;
        private float nextAttack = 0;
        
        [Header("Movement")]
        [SerializeField] private GameObject groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private bool isGrounded;
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        
        [Header("Attack")]
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackDistance;
        [SerializeField] private float attackRate = 1f;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private float damage;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            movementDirection = Input.GetAxisRaw("Horizontal");
            CheckAnimations();
            CheckDirection();
            CheckSurface();
            Jump();
            LeftRight();
            if (Time.time > nextAttack)
            {
                if(Input.GetKey(KeyCode.Space))
                {
                    Attack();
                    nextAttack = Time.time + 1f / attackRate;
                }
            }
        }
        private void LeftRight()
        {
            rb.velocity = new Vector2(movementDirection * speed, rb.velocity.y);
        }
        private void Jump()
        {
            if(isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        
        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        
        private void Attack()
        {
            int num = Random.Range(0, 2);
            if (num == 0)
                animator.SetTrigger("Attack1");
            else
                animator.SetTrigger("Attack2");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackDistance, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
            }
        }

        private void CheckSurface()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position,groundCheckRadius,groundLayer);
        }
        
        private void CheckDirection()
        {
            if (isFacingRight && movementDirection < 0)
                Flip();
            else if (!isFacingRight && movementDirection > 0)
                Flip();
        }
        private void CheckAnimations()
        {
            animator.SetBool("isGrounded",isGrounded);
            animator.SetFloat("yVelocity",rb.velocity.y);
            animator.SetFloat("runSpeed",Mathf.Abs(movementDirection * speed));
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheck.transform.position,groundCheckRadius);
            Gizmos.DrawWireSphere(attackPoint.position,attackDistance);
        }


    }
}

