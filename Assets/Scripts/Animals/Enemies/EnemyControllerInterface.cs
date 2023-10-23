namespace Animals.Enemies
{
    public interface EnemyControllerInterface 
    {
        void Attack();
        void Move();
        void Damage(int damage);
        void Die();
    }
}
