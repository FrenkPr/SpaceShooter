using OpenTK;

namespace SpaceShooter
{
    enum EnemyType
    {
        DefaultEnemy,
        RedEnemy,
        BossEnemy,
        Length
    }

    abstract class Enemy : Actor
    {
        private float timeToNextShoot;
        public EnemyType Type;
        public uint Score { get; protected set; }

        public Enemy(string textureName, Vector2 moveSpeed) : base(textureName, moveSpeed)
        {
            sprite.FlipX = true;
            timeToNextShoot = 1;

            RigidBody.Type = RigidBodyType.Enemy;

            RigidBody.AddCollisionType(RigidBodyType.Player);
            RigidBody.AddCollisionType(RigidBodyType.PlayerBullet);
        }

        public override void Shoot()
        {
            if (IsActive)
            {
                timeToNextShoot -= Game.DeltaTime;

                if (timeToNextShoot <= 0)
                {
                    timeToNextShoot = RandomGenerator.GetRandomFloat() * 2 + 1;

                    base.Shoot();
                }
            }
        }

        public override void Move()
        {
            if (IsActive)
            {
                base.Move();

                EnergyBar.Position = new Vector2(sprite.position.X - HalfWidth, sprite.position.Y - HalfHeight - 20);
            }
        }

        public override void CheckOutOfScreen()
        {
            //Position = enemy position
            if (IsActive && Position.X + HalfWidth < 0)
            {
                EnemyMngr.RestoreEnemy(this);
            }
        }

        public override void OnDie()
        {
            EnemyMngr.RestoreEnemy(this);
        }
    }
}
