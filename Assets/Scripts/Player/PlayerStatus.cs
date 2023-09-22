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

        private InterfaceWorldController ui;
        [SerializeField]
        private bool chaveSairCasa = false;
        
        private void Awake()
        {
            Health = MaxHealth;
            ui = GameObject.Find("Canvas").GetComponent<InterfaceWorldController>();
            
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            ui.Atualiza();
            CheckIfDead();
        }

        private void CheckIfDead()
        {
            if (Health <= 0)
            {
                Time.timeScale = 0;
                Debug.Log("Você morreu");
            }
        }

        public void PegarChave()
        {
            chaveSairCasa = true;
        }

        public bool VerificaChave()
        {
            return chaveSairCasa;
        }
    }
}