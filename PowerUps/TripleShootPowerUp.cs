using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class TripleShootPowerUp : TimedPowerUp
    {
        private float tripleShootTimer;

        public TripleShootPowerUp() : base("tripleShootPowerUp", new OpenTK.Vector2(-700, 0), 20)
        {

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
            }

            if (player != null)
            {
                tripleShootTimer -= Game.DeltaTime;

                if (tripleShootTimer <= 0)
                {
                    player.WeaponType = WeaponType.Default;
                    OnDetach();
                }
            }
        }

        public override void OnCollision(GameObject other)
        {
            OnAttach((Player)other);

            player.WeaponType = WeaponType.TripleShoot;
            tripleShootTimer = 10;

            PowerUpsMngr.RestorePowerUp(this);
        }
    }
}
