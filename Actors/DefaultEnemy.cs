

namespace SpaceShooter
{
    class DefaultEnemy : Enemy
    {
        public DefaultEnemy() : base("defaultEnemy", new OpenTK.Vector2(-250, 0))
        {
            shootOffset = new OpenTK.Vector2(-sprite.pivot.X, sprite.pivot.Y * 0.5f);
            bulletType = BulletType.DefaultEnemyBullet;

            shootSpeed = new OpenTK.Vector2(-1000, 0);

            Type = EnemyType.DefaultEnemy;

            Score = 25;
        }
    }
}
