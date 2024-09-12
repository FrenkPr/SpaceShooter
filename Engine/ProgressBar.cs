using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class ProgressBar : GameObject
    {
        private Texture barTexture;
        private Sprite barSprite;
        private Vector2 barOffset;
        private int barWidth;
        public override Vector2 Position { get { return base.Position; } set { base.Position = value; barSprite.position = value + barOffset; } }

        public ProgressBar(string frameTextureId, string barId, Vector2 barOffset) : base(frameTextureId)
        {
            sprite.pivot = Vector2.Zero;

            barTexture = TextureMngr.GetTexture(barId);
            barSprite = new Sprite(barTexture.Width, barTexture.Height);

            barWidth = barTexture.Width;
            this.barOffset = barOffset;

            DrawMngr.Add(this);
        }

        public void Scale(float scale)
        {
            scale = MathHelper.Clamp(scale, 0, 1);

            barSprite.scale.X = scale;
            barWidth = (int)(barSprite.Width * scale);

            barSprite.SetMultiplyTint((1 - scale) * 50, scale * 2, scale, 1);
        }

        public override void Draw()
        {
            if (IsActive)
            {
                base.Draw();
                barSprite.DrawTexture(barTexture, 0, 0, barWidth, (int)barSprite.Height);
            }
        }
    }
}
