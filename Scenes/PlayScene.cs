using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpaceShooter
{
    class PlayScene : Scene
    {
        private Background background;
        private List<Player> players;

        public PlayScene() : base()
        {

        }

        private void LoadAssets()
        {
            TextureMngr.AddTexture("player", "Assets/player_ship.png");
            TextureMngr.AddTexture("defaultEnemy", "Assets/enemy_ship.png");
            TextureMngr.AddTexture("redEnemy", "Assets/redEnemy_ship.png");
            TextureMngr.AddTexture("bossEnemy", "Assets/big_ship.png");
            TextureMngr.AddTexture("background", "Assets/spaceBg.png");
            TextureMngr.AddTexture("playerBullet", "Assets/blueLaser.png");
            TextureMngr.AddTexture("defaultEnemyBullet", "Assets/beams.png");
            TextureMngr.AddTexture("redEnemyBullet", "Assets/fireGlobe.png");
            TextureMngr.AddTexture("bossBullet", "Assets/greenLaser.png");
            TextureMngr.AddTexture("textImage", "Assets/comics.png");
            TextureMngr.AddTexture("frameProgressBar", "Assets/loadingBar_frame.png");
            TextureMngr.AddTexture("progressBar", "Assets/loadingBar_bar.png");
            TextureMngr.AddTexture("energyPowerUp", "Assets/powerUp_battery.png");
            TextureMngr.AddTexture("tripleShootPowerUp", "Assets/powerUp_triple.png");
        }

        public override void Start()
        {
            base.Start();

            LoadAssets();
            PhraseMngr.Init();

            background = new Background();

            players = new List<Player>(Game.JoypadCtrls.Count);

            for (int i = 0; i < Game.JoypadCtrls.Count; i++)
            {
                players.Add(new Player(i));
            }

            if (Game.JoypadCtrls.Count == 0)
            {
                players.Add(new Player(0));
            }

            BulletMngr.Init();
            EnemyMngr.Init();
            PowerUpsMngr.Init();
        }

        public override void Update()
        {
            EnemyMngr.SpawnEnemies();
            PowerUpsMngr.Spawn();

            players[0].KeyboardInput();

            for (int i = 0; i < Game.JoypadCtrls.Count; i++)
            {
                players[i].JoypadInput();
            }

            //shootings
            ShootMngr.Shoot();

            //update
            MoveMngr.Move();

            //checkings
            OutOfScreenMngr.CheckOutOfScreen();
            PhysicsMngr.CheckCollisions();
            
            //draw
            DrawMngr.Draw();
            DebugMngr.Draw();

            //printing phrases
            PhraseMngr.PrintPhrases();

            if (AllPlayersDead())
            {
                IsPlaying = false;

                Game.Window.Update();
                Thread.Sleep(2000);
            }
        }

        private bool AllPlayersDead()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].IsAlive)
                {
                    return false;
                }
            }

            return true;
        }

        public override void OnExit()
        {
            EnemyMngr.ClearAll();
            BulletMngr.ClearAll();
            PowerUpsMngr.ClearAll();
            ShootMngr.ClearAll();
            MoveMngr.ClearAll();
            OutOfScreenMngr.ClearAll();
            PhysicsMngr.ClearAll();
            PhraseMngr.ClearAll();
            DrawMngr.ClearAll();
            TextureMngr.ClearAll();
            DebugMngr.ClearAll();

            players = null;
            background = null;
            NextScene = new GameOverScene();
        }
    }
}
