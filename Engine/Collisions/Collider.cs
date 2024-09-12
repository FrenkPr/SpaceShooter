using System;
using OpenTK;

namespace SpaceShooter
{
    abstract class Collider
    {
        public Vector2 Offset;
        public RigidBody RigidBody;
        public Vector2 Position { get { return RigidBody.Position + Offset; } }

        public Collider(RigidBody owner)
        {
            RigidBody = owner;
            Offset = Vector2.Zero;
        }

        public abstract bool Collides(Collider other);
        public abstract bool Collides(CircleCollider other);
        public abstract bool Collides(BoxCollider other);
        public abstract bool Collides(CompoundCollider other);
    }
}
