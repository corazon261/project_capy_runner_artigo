using Animals.Enemies;
using UnityEngine;

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
        private bool isOnJumpable;
        private PlayerAnimator playerAnimator;
        private bool isOnSlope;
        private bool isJumping;
        private Vector2 perpendicularSpeed;
        private float groundAngle;
        private Vector2 groundNormal;
        private Vector2 position;
        private float spriteSizeX;


        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            rig.gravityScale = GravityScale;
            playerAnimator = GetComponent<PlayerAnimator>();
            playerStatus = GetComponent<PlayerStatus>();
            spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        public void Update()
        {
            position = transform.position;
            directionX = Input.GetAxis("Horizontal");
            transform.position = new Vector3(position.x, position.y, -5);
            HandleInput();
            Move();
            DetectGround();
            DetectSlope();
        }

        private void HandleInput()
        {
            if (Input.GetButtonDown("Jump") && isOnJumpable && !isJumping)
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
            playerAnimator.FlipX(directionX);
            var vel = directionX * (playerStatus.Speed);

            if (isOnSlope && !isJumping)
            {
                rig.velocity = new Vector2(-vel * perpendicularSpeed.x, -vel * perpendicularSpeed.y); 
            }
            else
            {
                rig.velocity = new Vector2(vel, rig.velocity.y);
            }
            
            VelocityLimiter();
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
            
            var enemy = Physics2D.OverlapCircle(transform.position, playerStatus.AttackRange, playerStatus.EnemyLayer);
            if (enemy != null)
            {
                Debug.Log("Enemy hit");
                enemy.GetComponent<EnemyControllerInterface>().Damage(playerStatus.Strength);
            }
        }

        private void DetectGround()
        {
            var hitGroundLeft = Physics2D.Raycast(position - new Vector2(spriteSizeX, 0), Vector2.down, DistanceToGround, GroundMask);
            var hitGroundMiddle = Physics2D.Raycast(position, Vector3.down, DistanceToGround, GroundMask);
            var hitGroundRight = Physics2D.Raycast(position + new Vector2(spriteSizeX, 0), Vector2.down, DistanceToGround, GroundMask);
            
            var hitJumpableMiddle = Physics2D.Raycast(position, Vector3.down, DistanceToGround, JumpableMask);
            var hitJumpableLeft = Physics2D.Raycast(position - new Vector2(spriteSizeX, 0), Vector2.down, DistanceToGround, JumpableMask);
            var hitJumpableRight = Physics2D.Raycast(position + new Vector2(spriteSizeX, 0), Vector2.down, DistanceToGround, JumpableMask);
            
            var onGround = hitGroundLeft || hitGroundMiddle || hitGroundRight;
            var onJumpable = hitJumpableLeft || hitJumpableMiddle || hitJumpableRight;
            
            isOnJumpable = onGround || onJumpable;
            
            Debug.DrawRay(position, Vector3.down * DistanceToGround, Color.red);
            Debug.DrawRay(position - new Vector2(spriteSizeX / 3, 0), Vector3.down * DistanceToGround, Color.red);
            Debug.DrawRay(position + new Vector2(spriteSizeX / 3, 0), Vector3.down * DistanceToGround, Color.red);
            
            groundNormal = hitGroundMiddle.normal;
            groundAngle = Vector2.Angle(Vector2.up, groundNormal);
        }

        private void DetectSlope()
        {
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

        private void VelocityLimiter()
        {
            var vel = new Vector2(0, Mathf.Clamp(rig.velocity.y, -MaxVelocityDown, MaxVelocityUp));
            vel.x = Mathf.Clamp(rig.velocity.x, -MaxVelocityLeft, MaxVelocityRight);
            rig.velocity = vel;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.CompareTag("Box") || other.gameObject.layer == LayerMask.NameToLayer("Harmable"))
            {
                isJumping = false;
                playerAnimator.PlayAnimation();
                playerAnimator.FallAnimation();
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.CompareTag("Box") || other.gameObject.layer == LayerMask.NameToLayer("Harmable"))
            {
                isJumping = false;
                playerAnimator.PlayAnimation();
            }
        }
    }
}
