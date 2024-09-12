using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class EnergyPowerUp : TimedPowerUp
    {
        public EnergyPowerUp() : base("energyPowerUp", new OpenTK.Vector2(-700, 0), 10)
        {
            rotationSpeed = -7;
        }

        public override void GetPowerUp(Player p)
        {
            OnCollision(p);
        }

        public override void Move()
        {
            if (IsActive)
            {
                base.Move();
                sprite.Rotation += rotationSpeed * Game.DeltaTime;
            }
        }

        public override void OnCollision(GameObject other)
        {
            OnAttach((Player)other);

            player.ResetEnergy();

            OnDetach();

            PowerUpsMngr.RestorePowerUp(this);
        }
    }
}
