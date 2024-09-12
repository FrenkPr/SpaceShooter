using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class BossEnemy : Enemy
    {
        public BossEnemy() : base("bossEnemy", new Vector2(-50, 0))
        {
            //DebugMngr.RemoveItem(RigidBody.Collider);  //removes old collider

            Dmg = 50;

            maxEnergy = 1000;
            ResetEnergy();

            shootOffset = new Vector2(-sprite.pivot.X, sprite.pivot.Y - 37);
            bulletType = BulletType.BossBullet;

            shootSpeed = new Vector2(-1000, 0);

            Type = EnemyType.BossEnemy;

            RigidBody.Collider = ColliderFactory.CreateCompoundFor(this, ColliderFactory.CreateBoxFor(this));

            BoxCollider box1 = new BoxCollider(RigidBody, HalfWidth + 100, HalfHeight * 2 - 40);
            box1.Offset = new Vector2(40, 0);

            BoxCollider box2 = new BoxCollider(RigidBody, HalfWidth * 2, 25);
            box2.Offset = new Vector2(0, 75);

            BoxCollider box3 = new BoxCollider(RigidBody, 80, 20);
            box3.Offset = new Vector2(68, 90);

            ((CompoundCollider)RigidBody.Collider).AddSubCollider(box1);
            ((CompoundCollider)RigidBody.Collider).AddSubCollider(box2);
            ((CompoundCollider)RigidBody.Collider).AddSubCollider(box3);

            //DebugMngr.AddItem(RigidBody.Collider);  //adds new collider (CompoundCollider)

            Score = 1000;
        }
    }
}
