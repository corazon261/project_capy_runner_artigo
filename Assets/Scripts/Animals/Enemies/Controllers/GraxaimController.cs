using System;
using Player;
using UnityEngine;

namespace Animals.Enemies.Controllers
{
    public class GraxaimController : EnemyController
    {
        public float Speed;
        public float FocalDistance = 15;
        public float AttackDistance = 4;
        
        private Rigidbody2D rig;
        private Transform player;
        private bool readyForAttack;
        private float distance;
        private SpriteRenderer spriteRenderer;
        private Animator animator;
        
        private static readonly int Movendo = Animator.StringToHash("Movendo");
        private static readonly int Atacando = Animator.StringToHash("Atacando");

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            distance = Vector2.Distance(transform.position, player.position);
            
            if (distance < AttackDistance)
            {
                readyForAttack = true;
                Attack();
            }
            
            if (distance > AttackDistance && readyForAttack)
            {
                readyForAttack = false;
                animator.SetBool(Atacando, false);
            }
            
            if (distance < FocalDistance && !readyForAttack)
            {
                var playerDirection = player.position.x - transform.position.x;
                playerDirection = playerDirection switch
                {
                    > 0 => 1,
                    < 0 => -1,
                    _ => playerDirection
                };
                
                FlipX(playerDirection > 0);
                
                rig.velocity = new Vector2(playerDirection * Speed, rig.velocity.y);
            }

            if (Mathf.Abs(rig.velocity.x) > 0.3f)
            {
                animator.SetBool(Movendo, true);
            }
            else
            {
                animator.SetBool(Movendo, false);
            }
        }

        private void FlipX(bool flipX)
        {
            spriteRenderer.flipX = flipX;
        } 
        public override void Attack()
        {
            animator.SetBool(Atacando, true);
        }

        public override void Move()
        {
            Debug.Log("Attacked");
        }

        public override void Damage(int damage)
        {
            Debug.Log("Attacked");
        }

        public override void Die()
        {
            Debug.Log("Attacked");
        }
        
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, AttackDistance);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, FocalDistance);
        }

        public void GiveDamage()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerStatus>().TakeDamage(1);
        }
    }
}