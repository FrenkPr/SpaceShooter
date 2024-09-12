using OpenTK;

namespace SpaceShooter
{
    abstract class PowerUp : GameObject
    {
        protected Player player;

        public PowerUp(string textureId, Vector2 moveSpeed) : base(textureId)
        {
            RigidBody = new RigidBody(this, moveSpeed);
            RigidBody.Collider = ColliderFactory.CreateCircleFor(this);

            RigidBody.Type = RigidBodyType.PowerUp;
            RigidBody.AddCollisionType(RigidBodyType.Player);

            DrawMngr.Add(this);
            MoveMngr.Add(this);
            OutOfScreenMngr.Add(this);
        }

        public override void CheckOutOfScreen()
        {
            if (IsActive && Position.X + HalfWidth < 0)
            {
                PowerUpsMngr.RestorePowerUp(this);
            }
        }

        public virtual void GetPowerUp(Player p)
        {

        }

        public virtual void OnAttach(Player p)
        {
            player = p;
        }

        public void OnDetach()
        {
            player = null;
        }
    }
}
