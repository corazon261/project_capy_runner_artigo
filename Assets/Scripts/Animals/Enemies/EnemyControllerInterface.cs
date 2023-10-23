namespace Animals.Enemies
{
    public interface EnemyControllerInterface 
    {
        void Attack(bool attack = true);
        void Move();
        void Damage(int damage);
        void Die();
    }
}
