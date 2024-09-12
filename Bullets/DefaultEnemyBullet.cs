

namespace SpaceShooter
{
    class DeafultEnemyBullet : EnemyBullet
    {
        //width: 74
        //height: 46
        //offset x: 156
        //offset y: 227
        public DeafultEnemyBullet() : base("defaultEnemyBullet", 74, 46)
        {
            Type = BulletType.DefaultEnemyBullet;
        }

        public override void Draw()
        {
            if (IsActive)
            {
                sprite.DrawTexture(texture, 156, 227, Width, Height);
            }
        }
    }
}
