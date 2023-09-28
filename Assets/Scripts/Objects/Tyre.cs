using UnityEngine;

namespace Objects
{
    public class Tyre : MonoBehaviour
    {
        public float JumpForce = 13;
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
            {
                animator.SetTrigger("pular");
                var rig = other.gameObject.GetComponent<Rigidbody2D>();
                rig.AddForce(new Vector2(0f, JumpForce - rig.velocity.y), ForceMode2D.Impulse);
            }
        }
    }
}
