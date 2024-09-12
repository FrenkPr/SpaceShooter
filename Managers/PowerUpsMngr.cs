using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    static class PowerUpsMngr
    {
        private static List<PowerUp> powerUps;

        static PowerUpsMngr()
        {
            powerUps = new List<PowerUp>();
        }

        public static void Init()
        {
            Add(new EnergyPowerUp());
            Add(new TripleShootPowerUp());
        }

        public static void Add(PowerUp item)
        {
            powerUps.Add(item);
        }

        public static void Remove(PowerUp item)
        {
            powerUps.Remove(item);
        }

        public static void ClearAll()
        {
            powerUps.Clear();
        }

        public static void RestorePowerUp(PowerUp powerUp)
        {
            powerUp.IsActive = false;
            Add(powerUp);
        }

        public static void Spawn()
        {
            for (int i = 0; i < powerUps.Count; i++)
            {
                if (powerUps[i] is TimedPowerUp powerUp)
                {
                    if (powerUp.TimeToNextPowerUp())
                    {
                        powerUp.Position = new Vector2(Game.WindowWidth + powerUp.HalfWidth, /*Game.WindowHeight * 0.5f*/RandomGenerator.GetRandomInt(powerUp.HalfHeight, Game.WindowHeight - powerUp.HalfHeight));
                        powerUp.IsActive = true;

                        powerUps.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
}
