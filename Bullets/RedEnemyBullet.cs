using OpenTK;
using System;

namespace SpaceShooter
{
    class RedEnemyBullet : EnemyBullet
    {
        private float currentVerticalOscillationAngleRads;
        private float verticalOscillationSpeed;
        private float verticalOscillationLength;
        public Vector2 BasePosition;

        public RedEnemyBullet() : base("redEnemyBullet")
        {
            Dmg = 50;
            Type = BulletType.RedEnemyBullet;
            verticalOscillationSpeed = 2;
            verticalOscillationLength = 100;
            currentVerticalOscillationAngleRads = 0;
            rotationSpeed = -11;

            RigidBody.Collider = ColliderFactory.CreateCircleFor(this);
        }

        public override void Move()
        {
            if (IsActive)
            {
                currentVerticalOscillationAngleRads += verticalOscillationSpeed * Game.DeltaTime;
                float y = (float)Math.Sin(currentVerticalOscillationAngleRads);

                Vector2 angleVector = new Vector2(0, y);

                //RigidBody.CurrentMoveSpeed.Y = angleVector.Y * verticalOscillationLength;
                sprite.position.Y = angleVector.Y * verticalOscillationLength + BasePosition.Y;

                base.Move();

                Rotation += rotationSpeed * Game.DeltaTime;
            }
        }

        public override void Reset()
        {
            base.Reset();

            //negativeVerticalOscillation = false;
            RigidBody.CurrentMoveSpeed.Y = 0;
            verticalOscillationSpeed = 0;
        }
    }
}
