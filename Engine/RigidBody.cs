using System;
using System.Collections.Generic;
using OpenTK;
using Aiv.Fast2D;

namespace SpaceShooter
{
    enum RigidBodyType { Player = 1, PlayerBullet = 2, Enemy = 4, EnemyBullet = 8, PowerUp = 16 }

    class RigidBody
    {
        public GameObject GameObject;
        public Collider Collider;
        public bool IsCollisionAffected;
        public RigidBodyType Type;
        protected uint collisionMask;
        public bool IsActive { get { return GameObject.IsActive; } }
        public Vector2 Position { get { return GameObject.Position; } set { GameObject.Position = value; } }
        public Vector2 CurrentMoveSpeed;

        public RigidBody(GameObject owner, Vector2 speed)
        {
            GameObject = owner;
            CurrentMoveSpeed = speed;
            IsCollisionAffected = true;

            PhysicsMngr.Add(this);
        }

        public bool Collides(RigidBody otherBody)
        {
            return Collider.Collides(otherBody.Collider);
        }

        public void Move()
        {
            if (IsActive)
            {
                Position += CurrentMoveSpeed * Game.DeltaTime;  //updates game object position
            }
        }

        public void AddCollisionType(RigidBodyType type)
        {
            collisionMask |= (uint)type;
        }

        public bool CollisionTypeMatches(RigidBodyType type)
        {
            return ((uint)type & collisionMask) != 0;
        }
    }
}
