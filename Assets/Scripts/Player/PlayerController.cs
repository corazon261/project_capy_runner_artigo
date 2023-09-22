using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float GravityScale = 2;
        private PlayerStatus playerStatus;
        private float directionX;
        private Rigidbody2D rig;
        private bool isGrounded;
        private PlayerAnimator playerAnimator;
        
        
        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            rig.gravityScale = GravityScale;
            playerAnimator = GetComponent<PlayerAnimator>();
            playerStatus = GetComponent<PlayerStatus>();
        }

        public void Update()
        {
            directionX = Input.GetAxis("Horizontal");
            HandleInput();
            Move();
            playerAnimator.FlipX(directionX);
        }

        private void HandleInput()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                playerAnimator.JumpAnimation();
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                playerAnimator.AttackAnimation();
                Attack();
            }   
        }

        public float GetDirectionX()
        {
            return directionX;
        }

        private void Move()
        {
            var movement = new Vector3(directionX, 0f);
            transform.position += movement * (Time.deltaTime * playerStatus.Speed);

            playerAnimator.MoveAnimation(Input.GetButton("Horizontal"));
        }

        private void Jump()
        {
            rig.AddForce(new Vector2(0f, playerStatus.JumpForce), ForceMode2D.Impulse);
        }
        
        private void Attack()
        {
            playerAnimator.AttackAnimation();
        }
            
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.CompareTag("Box"))
            {
                isGrounded = true;
                playerAnimator.FallAnimation();
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.CompareTag("Box"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.CompareTag("Box"))
            {
                isGrounded = false;
            }
        }
    }
}
