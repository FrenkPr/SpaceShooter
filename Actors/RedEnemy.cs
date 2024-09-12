

namespace SpaceShooter
{
    class RedEnemy : Enemy
    {
        public RedEnemy() : base("redEnemy", new OpenTK.Vector2(-50, 0))
        {
            maxEnergy = 150;
            ResetEnergy();

            shootOffset = new OpenTK.Vector2(-sprite.pivot.X, 0);
            bulletType = BulletType.RedEnemyBullet;

            shootSpeed = new OpenTK.Vector2(-300, 0);

            Type = EnemyType.RedEnemy;

            Score = 50;
        }
    }
}