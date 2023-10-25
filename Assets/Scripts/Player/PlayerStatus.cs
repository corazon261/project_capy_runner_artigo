using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerStatus : MonoBehaviour
    {
        public int MaxHealth = 5; 
        public int Health; 
        public int Strength = 1;
        public float Speed = 5;
        public float JumpForce = 10;
        private PlayerAnimator animator;

        public Canvas Ui;
        private InterfaceWorldController interfaceWorldController;
        public float AttackRange = 2;
        public LayerMask EnemyLayer;

        private void Awake()
        {
            Health = MaxHealth;
            interfaceWorldController = Ui.GetComponent<InterfaceWorldController>();
            animator = GetComponent<PlayerAnimator>();
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            animator.HurtAnimation();
            interfaceWorldController.Atualiza();
            CheckIfDead();
        }

        private void CheckIfDead()
        {
            if (Health <= 0)
            {
                SceneManager.LoadScene("Start Game");
                Debug.Log("Você morreu");
            }
        }
        
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, AttackRange);
        }
    }
}