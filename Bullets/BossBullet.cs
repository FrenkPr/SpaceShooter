using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class BossBullet:EnemyBullet
    {
        public BossBullet() : base("bossBullet")
        {
            Dmg = 50;
            Type = BulletType.BossBullet;

            RigidBody.Collider = ColliderFactory.CreateCircleFor(this);
        }
    }
}
