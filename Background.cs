using Aiv.Fast2D;

namespace SpaceShooter
{
    class Background : IDrawable, IMovable
    {
        private Texture texture;
        private Sprite background1;
        private Sprite background2;
        private float moveSpeedX;

        public Background()
        {
            texture = TextureMngr.GetTexture("background");
            background1 = new Sprite(texture.Width, texture.Height);
            background2 = new Sprite(texture.Width, texture.Height);
            moveSpeedX = -600;

            MoveMngr.Add(this);
            DrawMngr.Add(this);
        }

        public void Move()
        {
            background1.position.X += moveSpeedX * Game.DeltaTime;

            if (background1.position.X <= -background1.Width)
            {
                background1.position.X += background1.Width;
            }

            background2.position.X = background1.position.X + background1.Width;
        }

        public void Draw()
        {
            background1.DrawTexture(texture);
            background2.DrawTexture(texture);
        }
    }
}
