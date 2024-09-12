using OpenTK;

namespace SpaceShooter
{
    enum BulletType
    {
        PlayerBullet,
        DefaultEnemyBullet,
        RedEnemyBullet,
        BossBullet,
        Length
    }

    abstract class Bullet : GameObject
    {
        public int Dmg;

        public BulletType Type { get; protected set; }
        public float Rotation { get => sprite.Rotation; set => sprite.Rotation = value; }
        protected Vector2 startPosition;

        public Bullet(string textureName, int width = 0, int height = 0) : base(textureName, width, height)
        {
            OutOfScreenMngr.Add(this);
            MoveMngr.Add(this);
            DrawMngr.Add(this);

            RigidBody = new RigidBody(this, Vector2.Zero);
            RigidBody.Collider = ColliderFactory.CreateBoxFor(this);
        }

        public override void CheckOutOfScreen()
        {
            if (IsActive && Position.X + HalfWidth < 0)
            {
                BulletMngr.RestoreBullet(this);
            }
        }

        public void Shoot(Vector2 pos, Vector2 speed)
        {
            Position = pos;
            startPosition = Position;
            RigidBody.CurrentMoveSpeed = speed;
        }

        public override void OnCollision(GameObject other)
        {
            BulletMngr.RestoreBullet(this);

            if (other is Bullet)
            {
                BulletMngr.RestoreBullet((Bullet)other);
            }

            else if (this is PlayerBullet && other is Enemy enemy)
            {
                enemy.AddDamage(Dmg);

                if (!enemy.IsAlive)
                {
                    if (Player.Score != uint.MaxValue)
                    {
                        Player.Score += enemy.Score;
                        PhraseMngr.EditPhrase("score", "SCORE:" + Player.Score.ToString("0000000000"));
                    }

                    if (Player.Score > uint.MaxValue)
                    {
                        Player.Score = uint.MaxValue;
                        PhraseMngr.EditPhrase("score", "SCORE:" + Player.Score.ToString("0000000000"));
                    }

                    if (Player.ScoreRecord < Player.Score)
                    {
                        Player.ScoreRecord = Player.Score;
                        PhraseMngr.EditPhrase("scoreRecord", "RECORD:" + Player.ScoreRecord.ToString("0000000000"));
                    }

                    enemy.OnDie();
                }
            }
        }

        public virtual void Reset()
        {
            IsActive = false;
            Rotation = 0;
        }
    }
}
