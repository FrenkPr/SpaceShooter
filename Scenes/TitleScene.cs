using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class TitleScene : Scene
    {
        private Screen startScreen;
        protected string screenTextureId;

        public TitleScene() : base()
        {
            screenTextureId = "startScreen";
        }

        protected virtual void LoadAssets()
        {
            TextureMngr.AddTexture("startScreen", "Assets/pressEnter.png");
        }

        public override void Start()
        {
            base.Start();

            LoadAssets();
            startScreen = new Screen(screenTextureId);
        }

        public override void Update()
        {
            if (startScreen.EnterPressed())
            {
                IsPlaying = false;
            }

            DrawMngr.Draw();
        }

        public override void OnExit()
        {
            DrawMngr.ClearAll();
            TextureMngr.ClearAll();

            startScreen = null;
            screenTextureId = null;

            NextScene = new PlayScene();
        }
    }
}
