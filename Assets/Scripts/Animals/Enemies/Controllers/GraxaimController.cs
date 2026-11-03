using System;
using Player;
using UnityEngine;

namespace Animals.Enemies.Controllers
{
    public class GraxaimController : EnemyController, EnemyControllerInterface
    {
        public float Speed;
        public float FocalDistance = 15;
        public float AttackDistance = 4;
        public int HP = 5;
        
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
                Attack(true);
            }
            
            if (distance > AttackDistance && readyForAttack)
            {
                readyForAttack = false;
                Attack(false);
            }
            
            if (distance < FocalDistance && !readyForAttack)
            {
                Move();
            }

            AnimationWalk();
        }

        
        public override void Attack(bool attack = true)
        {
            animator.SetBool(Atacando, attack);
        }

        public override void Move()
        {
            var playerDirection = player.position.x - transform.position.x;
            playerDirection = playerDirection switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => playerDirection
            };
                
            spriteRenderer.flipX = playerDirection > 0;
                
            rig.linearVelocity = new Vector2(playerDirection * Speed, rig.linearVelocity.y);
        }

        public override void Damage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                Die();
            }
            animator.SetTrigger("Dano");
        }

        public override void Die()
        {
            Destroy(gameObject);
        }
        
        public void AnimationWalk()
        {
            if (Mathf.Abs(rig.linearVelocity.x) > 0.3f)
            {
                animator.SetBool(Movendo, true);
            }
            else
            {
                animator.SetBool(Movendo, false);
            }
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