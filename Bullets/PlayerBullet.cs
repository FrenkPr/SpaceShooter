using OpenTK;

namespace SpaceShooter
{
    class PlayerBullet : Bullet
    {
        public PlayerBullet() : base("playerBullet")
        {
            Dmg = 25;
            Type = BulletType.PlayerBullet;

            RigidBody.Type = RigidBodyType.PlayerBullet;

            RigidBody.AddCollisionType(RigidBodyType.Enemy);
            RigidBody.AddCollisionType(RigidBodyType.EnemyBullet);
        }

        public override void CheckOutOfScreen()
        {
            if (IsActive && Position.X - HalfWidth >= Game.WindowWidth)
            {
                BulletMngr.RestoreBullet(this);
            }
        }
    }
}
