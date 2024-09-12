using System;
using OpenTK;

namespace SpaceShooter
{
    enum WeaponType
    {
        Default,
        TripleShoot
    }

    abstract class Actor : GameObject, IShootable
    {
        protected int energy;
        protected int maxEnergy;
        public int Dmg;  //the damage it takes to player in case of collision with enemy
        protected BulletType bulletType;
        protected Vector2 shootOffset;
        protected Vector2 shootSpeed;
        protected float tripleShootAngle;
        public WeaponType WeaponType;
        public bool IsAlive { get { return energy > 0; } }
        public ProgressBar EnergyBar;


        public Actor(string textureName, Vector2 moveSpeed, int width = 0, int height = 0) : base(textureName, width, height)
        {
            maxEnergy = 100;
            Dmg = 25;

            WeaponType = WeaponType.Default;

            EnergyBar = new ProgressBar("frameProgressBar", "progressBar", new Vector2(4));
            EnergyBar.Position = new Vector2(sprite.position.X - HalfWidth, sprite.position.Y - HalfHeight - 20);

            ResetEnergy();

            RigidBody = new RigidBody(this, moveSpeed);
            RigidBody.Collider = ColliderFactory.CreateBoxFor(this);

            //DebugMngr.AddItem(RigidBody.Collider);

            OutOfScreenMngr.Add(this);
            MoveMngr.Add(this);
            DrawMngr.Add(this);
            ShootMngr.Add(this);
        }

        public virtual void Shoot()
        {
            Bullet bullet;

            switch (WeaponType)
            {
                case WeaponType.Default:
                    bullet = BulletMngr.GetBullet(bulletType);

                    if (bullet != null)
                    {
                        if (bulletType == BulletType.RedEnemyBullet)
                        {
                            ((RedEnemyBullet)bullet).BasePosition = new Vector2(0, Position.Y);
                        }

                        bullet.Shoot(Position + shootOffset, shootSpeed);
                    }
                    break;

                case WeaponType.TripleShoot:
                    float x = (float)Math.Cos(tripleShootAngle);
                    float y = (float)Math.Sin(tripleShootAngle);
                    Vector2 bulletDirection = new Vector2(x, y);
                    float bulletRotation = y;

                    for (int i = 0; i < 3; i++)
                    {
                        bullet = BulletMngr.GetBullet(bulletType);

                        if (bullet != null)
                        {
                            bullet.Shoot(Position + shootOffset, bulletDirection.Normalized() * 1000);

                            bullet.Rotation = bulletRotation;
                            bulletRotation -= y;

                            bulletDirection.Y -= y;
                        }
                    }
                    break;
            }
        }

        public virtual void OnDie()
        {

        }

        public void ResetEnergy()
        {
            energy = maxEnergy;
            EnergyBar.Scale((float)energy / (float)maxEnergy);
        }

        public void AddDamage(int dmg)
        {
            energy -= dmg;
            EnergyBar.Scale((float)energy / (float)maxEnergy);
        }
    }
}
