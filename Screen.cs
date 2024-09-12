using Aiv.Fast2D;
using OpenTK;


namespace SpaceShooter
{
    class Screen : GameObject
    {
        private bool enterPressed;

        public Screen(string textureId) : base(textureId)
        {
            Position = new Vector2(Game.WindowWidth * 0.5f, Game.WindowHeight * 0.5f);
            enterPressed = false;
            IsActive = true;

            DrawMngr.Add(this);
        }

        public bool EnterPressed()
        {
            if (Game.KeyboardCtrl.IsValuePressed(KeyCode.Return))
            {
                enterPressed = true;
            }

            if (Game.JoypadCtrls.Count != 0)
            {
                if (Game.JoypadCtrls[0].IsValuePressed(JoypadValue.Start))
                {
                    enterPressed = true;
                }
            }

            return enterPressed;
        }
    }
}
