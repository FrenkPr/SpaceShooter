using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class BoxCollider : Collider
    {
        private int halfWidth;
        private int halfHeight;
        public int Width { get => halfWidth * 2; }
        public int Height { get => halfHeight * 2; }

        public BoxCollider(RigidBody owner, int width, int height) : base(owner)
        {
            halfWidth = (int)(width * 0.5f);
            halfHeight = (int)(height * 0.5f);
        }

        public override bool Collides(Collider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(CircleCollider circle)
        {
            float distX = circle.Position.X - Math.Max(Position.X - halfWidth, Math.Min(circle.Position.X, Position.X + halfWidth));
            float distY = circle.Position.Y - Math.Max(Position.Y - halfHeight, Math.Min(circle.Position.Y, Position.Y + halfHeight));

            return (distX * distX + distY * distY) < (circle.Radius * circle.Radius);
        }

        public override bool Collides(BoxCollider other)
        {
            float distX = other.Position.X - Position.X;
            float distY = other.Position.Y - Position.Y;

            return
                (Math.Abs(distX) <= halfWidth + other.halfWidth) &&
                (Math.Abs(distY) <= halfHeight + other.halfHeight);
        }

        public override bool Collides(CompoundCollider other)
        {
            return other.Collides(this);
        }
    }
}
