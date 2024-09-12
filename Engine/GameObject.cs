using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class GameObject : IDrawable, IMovable, IOutOfScreen
    {
        protected Texture texture;
        protected Sprite sprite;
        public RigidBody RigidBody;
        public bool IsActive;
        public virtual Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public int Width { get { return (int)sprite.Width; } }
        public int Height { get { return (int)sprite.Height; } }
        public int HalfWidth { get { return (int)(sprite.Width * 0.5f); } }
        public int HalfHeight { get { return (int)(sprite.Height * 0.5f); } }
        protected float rotationSpeed;

        public GameObject(string textureName, int spriteWidth = 0, int spriteHeight = 0)
        {
            texture = TextureMngr.GetTexture(textureName);

            spriteWidth = spriteWidth <= 0 ? texture.Width : spriteWidth;
            spriteHeight = spriteHeight <= 0 ? texture.Height : spriteHeight;

            sprite = new Sprite(spriteWidth, spriteHeight);

            sprite.pivot = new Vector2(spriteWidth * 0.5f, spriteHeight * 0.5f);
        }

        public virtual void OnCollision(GameObject other)
        {

        }

        public virtual void Move()
        {
            RigidBody.Move();
        }

        public virtual void CheckOutOfScreen()
        {

        }

        public virtual void Draw()
        {
            if (IsActive)
            {
                sprite.DrawTexture(texture);
            }
        }
    }
}
