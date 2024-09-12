using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    abstract class TimedPowerUp : PowerUp
    {
        private float timeToNextPowerUp;
        private float maxTimeToNextPowerUp;

        public TimedPowerUp(string textureId, Vector2 moveSpeed, float maxTimeToNextPowerUp) : base(textureId, moveSpeed)
        {
            this.maxTimeToNextPowerUp = maxTimeToNextPowerUp;
            timeToNextPowerUp = maxTimeToNextPowerUp;
        }

        public bool TimeToNextPowerUp()
        {
            timeToNextPowerUp -= Game.DeltaTime;

            if (timeToNextPowerUp <= 0)
            {
                timeToNextPowerUp = maxTimeToNextPowerUp;
                return true;
            }

            return false;
        }
    }
}
