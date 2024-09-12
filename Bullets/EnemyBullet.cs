using OpenTK;

namespace SpaceShooter
{
    abstract class EnemyBullet : Bullet
    {
        public EnemyBullet(string textureName, int width = 0, int height = 0) : base(textureName, width, height)
        {
            Dmg = 25;

            RigidBody.Type = RigidBodyType.EnemyBullet;

            RigidBody.AddCollisionType(RigidBodyType.Player);
            RigidBody.AddCollisionType(RigidBodyType.PlayerBullet);
        }
    }
}
