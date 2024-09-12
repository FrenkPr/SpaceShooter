using System.Collections.Generic;
using OpenTK;

namespace SpaceShooter
{
    static class EnemyMngr
    {
        private static Queue<Enemy>[] enemies;
        private static int numEnemies;
        private static float timeToNextSpawn;

        public static void Init()
        {
            numEnemies = 16;
            enemies = new Queue<Enemy>[(int)EnemyType.Length];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Queue<Enemy>(numEnemies);

                switch ((EnemyType)i)
                {
                    case EnemyType.DefaultEnemy:
                        for (int j = 0; j < numEnemies; j++)
                        {
                            enemies[i].Enqueue(new DefaultEnemy());
                        }
                        break;

                    case EnemyType.RedEnemy:
                        for (int j = 0; j < numEnemies; j++)
                        {
                            enemies[i].Enqueue(new RedEnemy());
                        }
                        break;

                    case EnemyType.BossEnemy:
                        for (int j = 0; j < numEnemies; j++)
                        {
                            enemies[i].Enqueue(new BossEnemy());
                        }
                        break;
                }
            }

            timeToNextSpawn = 3;
        }

        public static void RestoreEnemy(Enemy enemy)
        {
            enemies[(int)enemy.Type].Enqueue(enemy);
            enemy.IsActive = false;
            enemy.EnergyBar.IsActive = false;

            enemy.ResetEnergy();
        }

        public static void SpawnEnemies()
        {
            timeToNextSpawn -= Game.DeltaTime;

            if (timeToNextSpawn <= 0)
            {
                int randEnemyType = RandomGenerator.GetRandomInt((int)EnemyType.Length);

                SpawnEnemy(randEnemyType);
            }
        }

        private static void SpawnEnemy(int enemyType)
        {
            if (enemies[enemyType].Count > 0)
            {
                Enemy e = enemies[enemyType].Dequeue();
                e.IsActive = true;
                e.EnergyBar.IsActive = true;

                e.Position = new Vector2(Game.WindowWidth + e.HalfWidth, /*Game.WindowHeight * 0.5f*/RandomGenerator.GetRandomInt(e.HalfHeight + e.EnergyBar.Height, Game.WindowHeight - e.HalfHeight));

                timeToNextSpawn = /*200*/RandomGenerator.GetRandomInt(1, 4);
            }
        }

        public static void ClearAll()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Clear();
            }
        }
    }
}
