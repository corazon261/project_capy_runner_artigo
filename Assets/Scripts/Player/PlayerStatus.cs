using UnityEngine;

namespace Player
{
    public class PlayerStatus : MonoBehaviour
    {
        public int MaxHealth = 5; 
        public int Health; 
        public int Strength = 1;
        public float Speed = 5;
        public float JumpForce = 10;

        private void Start()
        {
            Health = MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        private void CheckIfDead()
        {
            if (Health <= 0)
            {
                Time.timeScale = 0;
                Debug.Log("Você morreu");
            }
        }
    }
}