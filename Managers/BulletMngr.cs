using System.Collections.Generic;

namespace SpaceShooter
{
    static class BulletMngr
    {
        private static Queue<Bullet>[] bullets;
        private static int numBullets;

        public static void Init()
        {
            numBullets = 320;
            bullets = new Queue<Bullet>[(int)BulletType.Length];

            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new Queue<Bullet>(numBullets);

                switch ((BulletType)i)
                {
                    case BulletType.PlayerBullet:
                        for (int j = 0; j < numBullets; j++)
                        {
                            bullets[i].Enqueue(new PlayerBullet());
                        }
                        break;

                    case BulletType.DefaultEnemyBullet:
                        for (int j = 0; j < numBullets; j++)
                        {
                            bullets[i].Enqueue(new DeafultEnemyBullet());
                        }
                        break;

                    case BulletType.RedEnemyBullet:
                        for (int j = 0; j < numBullets; j++)
                        {
                            bullets[i].Enqueue(new RedEnemyBullet());
                        }
                        break;

                    case BulletType.BossBullet:
                        for (int j = 0; j < numBullets; j++)
                        {
                            bullets[i].Enqueue(new BossBullet());
                        }
                        break;
                }
            }
        }

        public static void RestoreBullet(Bullet bullet)
        {
            bullets[(int)bullet.Type].Enqueue(bullet);
            bullet.Reset();
        }

        public static Bullet GetBullet(BulletType bulletType)
        {
            if (bullets[(int)bulletType].Count > 0)
            {
                Bullet b = bullets[(int)bulletType].Dequeue();
                b.IsActive = true;

                return b;
            }

            return null;
        }

        public static void ClearAll()
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].Clear();
            }
        }
    }
}
