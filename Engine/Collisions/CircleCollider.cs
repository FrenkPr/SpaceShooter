using System;
using OpenTK;

namespace SpaceShooter
{
    class CircleCollider : Collider
    {
        public float Radius;

        public CircleCollider(RigidBody owner, float radius) : base(owner)
        {
            Radius = radius;
        }

        public override bool Collides(Collider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(CircleCollider other)
        {
            Vector2 dist = other.Position - Position;
            return dist.LengthSquared <= (float)Math.Pow(other.Radius + Radius, 2);
        }

        public override bool Collides(BoxCollider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(CompoundCollider other)
        {
            return other.Collides(this);
        }
    }
}
