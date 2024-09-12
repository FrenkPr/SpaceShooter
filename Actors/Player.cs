using Aiv.Fast2D;
using OpenTK;
using System.IO;

namespace SpaceShooter
{
    class Player : Actor
    {
        //private float timeToNextBullet;
        private bool isFirePressed;
        public static uint Score;
        public static uint ScoreRecord;
        public static string RecordFilePath { get; private set; }
        private Vector2 maxMoveSpeed;
        private int id;

        public Player(int id) : base("player", Vector2.Zero)
        {
            this.id = id;

            Position = new Vector2(10 + HalfWidth, Game.WindowHeight * 0.5f);
            EnergyBar.Position = new Vector2(Position.X - HalfWidth, Position.Y - HalfHeight - 20);

            maxMoveSpeed = new Vector2(500);

            //timeToNextBullet = 0;
            IsActive = true;
            EnergyBar.IsActive = true;

            RigidBody.Type = RigidBodyType.Player;
            bulletType = BulletType.PlayerBullet;

            shootOffset = new Vector2(sprite.pivot.X + 15, sprite.pivot.Y - 10);

            RigidBody.AddCollisionType(RigidBodyType.Enemy | RigidBodyType.EnemyBullet | RigidBodyType.PowerUp);

            shootSpeed = new Vector2(1000, 0);

            tripleShootAngle = MathHelper.DegreesToRadians(15);

            Score = 0;
            ScoreRecord = 0;
            RecordFilePath = @"Record/record.dat";

            if (File.Exists(RecordFilePath))
            {
                ScoreRecord = uint.Parse(File.ReadAllText(RecordFilePath));
            }

            PhraseMngr.AddPhraseAt("scoreRecord", "RECORD:" + ScoreRecord.ToString("0000000000"), Vector2.Zero);
            PhraseMngr.AddPhraseAt("score", "SCORE:" + Score.ToString("0000000000"), new Vector2(0, 60));
        }

        private bool IsJoypadFirePressed()
        {
            if (Game.JoypadCtrls.Count != 0)
            {
                if (Game.JoypadCtrls[id].IsFirePressed())
                {
                    return true;
                }
            }

            return false;
        }

        #region MoveAndCollisions
        public override void CheckOutOfScreen()
        {
            //horizontal collisions
            if (Position.X - HalfWidth < 0)
            {
                sprite.position.X = HalfWidth;
                EnergyBar.Position = new Vector2(Position.X - HalfWidth, Position.Y - HalfHeight - 20);
            }

            else if (Position.X + HalfWidth > Game.WindowWidth)
            {
                sprite.position.X = Game.WindowWidth - HalfWidth;
                EnergyBar.Position = new Vector2(Position.X - HalfWidth, Position.Y - HalfHeight - 20);
            }

            //vertical collisions
            if (Position.Y - HalfHeight < 0)
            {
                sprite.position.Y = HalfHeight;
                EnergyBar.Position = new Vector2(Position.X - HalfWidth, Position.Y - HalfHeight - 20);
            }

            else if (Position.Y + HalfHeight > Game.WindowHeight)
            {
                sprite.position.Y = Game.WindowHeight - HalfHeight;
                EnergyBar.Position = new Vector2(Position.X - HalfWidth, Position.Y - HalfHeight - 20);
            }
        }

        public override void Shoot()
        {

        }

        public void KeyboardInput()
        {
            //if (id != 0)
            //{
            //    return;
            //}

            //MOVE INPUT
            Vector2 direction = new Vector2(Game.KeyboardCtrl.GetHorizontal(), Game.KeyboardCtrl.GetVertical());

            if (direction.Length > 1)
            {
                direction.Normalize();
            }

            RigidBody.CurrentMoveSpeed = maxMoveSpeed * direction;
            //END MOVE INPUT

            //SHOOT INPUT
            //timeToNextBullet -= Game.DeltaTime;

            //if ((Game.KeyboardCtrl.IsFirePressed() || IsJoypadFirePressed()) && timeToNextBullet <= 0)
            //{
            //    base.Shoot();
            //    timeToNextBullet = 0.6f;
            //}

            if ((Game.KeyboardCtrl.IsFirePressed() || IsJoypadFirePressed()) && IsActive)
            {
                if (!isFirePressed)
                {
                    base.Shoot();
                    isFirePressed = true;
                }
            }

            else if (isFirePressed)
            {
                isFirePressed = false;
            }
            //END SHOOT INPUT
        }

        public void JoypadInput()
        {
            if (Game.JoypadCtrls.Count == 0)
            {
                return;
            }

            //MOVE INPUT
            Vector2 direction = new Vector2(Game.JoypadCtrls[id].GetHorizontal(), Game.JoypadCtrls[id].GetVertical());

            if (direction.Length > 1)
            {
                direction.Normalize();
            }

            RigidBody.CurrentMoveSpeed = maxMoveSpeed * direction;
            //END MOVE INPUT

            //SHOOT INPUT
            //timeToNextBullet -= Game.DeltaTime;

            //if ((IsJoypadFirePressed() || Game.KeyboardCtrl.IsFirePressed()) && timeToNextBullet <= 0)
            //{
            //    base.Shoot();
            //    timeToNextBullet = 0.6f;
            //}

            if ((IsJoypadFirePressed() || Game.KeyboardCtrl.IsFirePressed()) && IsActive)
            {
                if (!isFirePressed)
                {
                    base.Shoot();
                    isFirePressed = true;
                }
            }

            else if (isFirePressed)
            {
                isFirePressed = false;
            }
            //END SHOOT INPUT
        }

        public override void OnDie()
        {
            IsActive = false;
            EnergyBar.IsActive = false;
        }

        public override void Move()
        {
            if (RigidBody.CurrentMoveSpeed.X != 0 || RigidBody.CurrentMoveSpeed.Y != 0)
            {
                base.Move();
                EnergyBar.Position += RigidBody.CurrentMoveSpeed * Game.DeltaTime;
            }
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Bullet bullet)
            {
                AddDamage(bullet.Dmg);
                BulletMngr.RestoreBullet(bullet);

                if (!IsAlive)
                {
                    OnDie();
                }
            }

            else if (other is Enemy enemy)
            {
                AddDamage(enemy.Dmg);
                EnemyMngr.RestoreEnemy(enemy);

                if (!IsAlive)
                {
                    OnDie();
                }
            }

            else if (other is PowerUp powerUp)
            {
                powerUp.GetPowerUp(this);
            }
        }

        #endregion
    }
}
