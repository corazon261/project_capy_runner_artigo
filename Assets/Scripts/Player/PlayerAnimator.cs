using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator animator;
        private SpriteRenderer spriteRenderer;
        
        private static readonly int Movendo = Animator.StringToHash("movendo");
        private static readonly int Atacar = Animator.StringToHash("atacar");
        private static readonly int TocarChao = Animator.StringToHash("tocarChao");
        private static readonly int Pular = Animator.StringToHash("pular");
        private static readonly int Dano = Animator.StringToHash("dano");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void PauseAnimation()
        {
            animator.speed = 0;
        }

        public void PlayAnimation()
        {
            animator.speed = 1;
        }
        
        public void JumpAnimation()
        {
            animator.SetTrigger(Pular);
        }

        public void FallAnimation()
        {
            animator.SetTrigger(TocarChao);
        }

        public void AttackAnimation()
        {
            animator.SetTrigger(Atacar);
        }

        public void HurtAnimation()
        {
            animator.SetTrigger(Dano);
        }

        public void FlipX(float directionX)
        {
            if (directionX > 0)
            {
                spriteRenderer.flipX = true;
            } else if (directionX < 0)
            {
                spriteRenderer.flipX = false;
            }            
            
            
        }

        public void MoveAnimation(bool isMoving)
        {
            animator.SetBool(Movendo, isMoving);   
        }
        
    }
}