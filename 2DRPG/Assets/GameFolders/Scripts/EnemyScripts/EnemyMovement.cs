using System;
using System.Collections;
using UnityEngine;

namespace TDRPG.EnemyScripts
{
    public class EnemyMovement : MonoBehaviour
    {
                
        [Header("Movement Checks")]
        [SerializeField] private Transform wallCheck;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform  gapCheck;
        [SerializeField] private bool wallDetected, groundDetected, gapDetected;
        [SerializeField] private float detectionRadius;
        [SerializeField] private LayerMask groundType;
        
        [Header("Movement Types")]
        [SerializeField] private bool isStatic;
        [SerializeField] private bool isWalker;
        [SerializeField] private bool isWalkingRight;
        [SerializeField] private bool isPatroller;
        [SerializeField] private bool isWaiter;
        
        [SerializeField] private float waitTime;
        private bool isWaiting;
        
        [Header("Patrolling Enemy")]
        [SerializeField] private Transform patrolPointA;
        [SerializeField] private Transform patrolPointB;
        private bool moveToA = true, moveToB;
        
        [SerializeField] private float moveSpeed;
        
        private Rigidbody2D rb;
        private Animator animator;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            MovementControls();

            if ((gapDetected || wallDetected) && groundDetected)
            {
                Flip();   
            }
        }
        private void FixedUpdate()
        {
            if (isStatic)
            {
                animator.SetBool("idle",true);
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            if (isWalker)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                animator.SetBool("idle",false);
                if (!isWalkingRight)
                {
                    rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
                }
            }
            
            if (isPatroller)
            {
                if (moveToA)
                {
                    if(!isWaiting)
                    {
                        rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, rb.velocity.y);
                        animator.SetBool("idle",false);
                    }
                    if (Vector2.Distance(transform.position, patrolPointA.position) < 0.2f)
                    {
                        if(isWaiter)
                        {
                            StartCoroutine(Waiting());
                        }
                        Flip();
                        moveToA = false;
                        moveToB = true;
                    }
                }

                if (moveToB)
                {
                    if (!isWaiting)
                    {
                        rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
                    }

                    if (Vector2.Distance(transform.position, patrolPointB.position) < 0.2f)
                    {
                        if(!isWaiting)
                        {
                            StartCoroutine(Waiting());
                        }
                        Flip();
                    }
                }
            }
        }
        
        IEnumerator Waiting()
        {
            animator.SetBool("idle",true);
            isWaiting = true;
            yield return new WaitForSecondsRealtime(waitTime);
            isWaiting = false;
            animator.SetBool("idle",false);
            Flip();
        }
        
        private void Flip()
        {
            isWalkingRight = !isWalkingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        
        private void MovementControls()
        {
            gapDetected = !Physics2D.OverlapCircle(gapCheck.position, detectionRadius, groundType);
            wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, groundType);
            groundDetected = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, groundType);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(gapCheck.position,detectionRadius);
            Gizmos.DrawWireSphere(wallCheck.position,detectionRadius);
            Gizmos.DrawWireSphere(groundCheck.position,detectionRadius);
        }
    }    
}

