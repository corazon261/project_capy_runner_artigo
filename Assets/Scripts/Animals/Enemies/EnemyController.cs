using UnityEngine;

namespace Animals.Enemies
{
    public abstract class EnemyController : MonoBehaviour, EnemyControllerInterface
    {
        public abstract void Attack();
        public abstract void Move();
        public abstract void Damage(int damage);
        public abstract void Die();
    }
}