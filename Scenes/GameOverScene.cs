using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using System.IO;

namespace SpaceShooter
{
    class GameOverScene : TitleScene
    {
        private KeyCode keyValuePressed;

        public GameOverScene()
        {
            screenTextureId = "gameOver";
        }

        protected override void LoadAssets()
        {
            TextureMngr.AddTexture("gameOver", "Assets/gameOverBg.png");
        }

        public override void Start()
        {
            base.Start();

            if (!File.Exists(Player.RecordFilePath))
            {
                File.WriteAllText(Player.RecordFilePath, Player.ScoreRecord.ToString("0000000000"));
            }

            else
            {
                uint oldRecord = uint.Parse(File.ReadAllText(Player.RecordFilePath));

                if (Player.ScoreRecord > oldRecord)
                {
                    File.WriteAllText(Player.RecordFilePath, Player.ScoreRecord.ToString("0000000000"));
                }
            }
        }

        public override void Update()
        {
            if (Game.KeyboardCtrl.IsValuePressed(KeyCode.Y) || Game.KeyboardCtrl.IsValuePressed(KeyCode.N))
            {
                if (Game.KeyboardCtrl.IsValuePressed(KeyCode.Y))
                {
                    keyValuePressed = KeyCode.Y;
                }

                else
                {
                    keyValuePressed = KeyCode.N;
                }

                IsPlaying = false;
            }

            if (Game.JoypadCtrls.Count != 0)
            {
                if (Game.JoypadCtrls[0].IsValuePressed(JoypadValue.PS4_X) ||
                    Game.JoypadCtrls[0].IsValuePressed(JoypadValue.A) ||
                    Game.JoypadCtrls[0].IsValuePressed(JoypadValue.Circle) ||
                    Game.JoypadCtrls[0].IsValuePressed(JoypadValue.B))
                {
                    if (Game.JoypadCtrls[0].IsValuePressed(JoypadValue.PS4_X) || Game.JoypadCtrls[0].IsValuePressed(JoypadValue.A))
                    {
                        keyValuePressed = KeyCode.Y;
                    }

                    else
                    {
                        keyValuePressed = KeyCode.N;
                    }

                    IsPlaying = false;
                }
            }

            DrawMngr.Draw();
        }

        public override void OnExit()
        {
            base.OnExit();

            if (keyValuePressed == KeyCode.N)
            {
                NextScene = null;
            }
        }
    }
}
