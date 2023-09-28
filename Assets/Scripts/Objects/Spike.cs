using Player;
using UnityEngine;

namespace Objects
{
    public class Spike : MonoBehaviour
    {
        public float ImpulseForce = 10;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerStatus>().TakeDamage(1);
                var directionX = other.gameObject.GetComponent<PlayerController>().GetDirectionX();
                var rig = other.gameObject.GetComponent<Rigidbody2D>();
                if (directionX > 0)
                {
                    directionX = -1;
                }
                else
                {
                    directionX = 1;
                }
                rig.AddForce(new Vector2((ImpulseForce * directionX), 5f), ForceMode2D.Impulse);
            }
        }
    }
}
