using UnityEngine;

namespace Animals.Enemies
{
    public abstract class EnemyController : MonoBehaviour, EnemyControllerInterface
    {
        public abstract void Attack(bool attack = true);
        public abstract void Move();
        public abstract void Damage(int damage);
        public abstract void Die();
    }
}