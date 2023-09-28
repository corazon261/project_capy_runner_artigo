using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float GravityScale = 2;
        public float MaxVelocityUp = 20;
        public float MaxVelocityDown = 15;
        public float MaxVelocityLeft = 15;
        public float MaxVelocityRight = 15;
        public float DistanceToGround = 5;
        public LayerMask GroundMask;
        public LayerMask JumpableMask;
        public PhysicsMaterial2D FrictionMaterial; 
        public PhysicsMaterial2D NoFrictionMaterial; 

        private PlayerStatus playerStatus;
        private float directionX;
        private Rigidbody2D rig;
        [SerializeField]
        private bool isGrounded;
        private PlayerAnimator playerAnimator;
        private bool isOnSlope;
        [SerializeField]
        private bool isJumping;
        private Vector2 perpendicularSpeed;


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

            Vector2 vel = new Vector2(0, Mathf.Clamp(rig.velocity.y, -MaxVelocityDown, MaxVelocityUp));
            vel.x = Mathf.Clamp(rig.velocity.x, -MaxVelocityLeft, MaxVelocityRight);
            rig.velocity = vel;
            
            DetectGround();
        }

        private void HandleInput()
        {
            if (Input.GetButtonDown("Jump") && isGrounded && !isJumping)
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
            var vel = directionX * (playerStatus.Speed);
            
            if (isOnSlope && !isJumping)
            {
                rig.velocity = new Vector2(-vel * perpendicularSpeed.x, -vel * perpendicularSpeed.y); 
            }
            else
            {
                rig.velocity = new Vector2(vel, rig.velocity.y);
            }

            playerAnimator.MoveAnimation(directionX != 0);
        }

        private void Jump()
        {
            isJumping = true;
            rig.AddForce(new Vector2(0f, playerStatus.JumpForce), ForceMode2D.Impulse);
        }

        private void Attack()
        {
            playerAnimator.AttackAnimation();
        }

        private void DetectGround()
        {
            var hitGround = Physics2D.Raycast(transform.position, Vector3.down, DistanceToGround, GroundMask);
            var hitBox = Physics2D.Raycast(transform.position, Vector3.down, DistanceToGround, JumpableMask);
            isGrounded = hitGround || hitBox;
            Debug.DrawRay(transform.position, Vector3.down * DistanceToGround, Color.red);
            
            Vector2 groundNormal = hitGround.normal;
            float groundAngle = Vector2.Angle(Vector2.up, groundNormal);
            if (groundAngle != 0)
            {
                perpendicularSpeed = Vector2.Perpendicular(groundNormal).normalized;
                isOnSlope = true;
            }
            else
            {
                isOnSlope = false;
            }

            rig.sharedMaterial = isOnSlope && Input.GetAxis("Horizontal") == 0 ? FrictionMaterial : NoFrictionMaterial;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.CompareTag("Box"))
            {
                isGrounded = true;
                isJumping = false;
                playerAnimator.FallAnimation();
            }
        }
    }
}
