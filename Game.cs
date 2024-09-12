using System.Collections.Generic;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    static class Game
    {
        public static Window Window { get; private set; }
        public static float DeltaTime { get { return Window.DeltaTime; } }
        public static int WindowWidth { get { return Window.Width; } }
        public static int WindowHeight { get { return Window.Height; } }
        private static Scene scene;
        public static KeyboardController KeyboardCtrl;
        public static List<JoypadController> JoypadCtrls;

        public static void Init()
        {
            Window = new Window(1280, 720, "Space shooter");
            Window.Position = new Vector2(-8, 0);

            KeyboardCtrl = new KeyboardController(0);

            string[] joypadsConnected = Window.Joysticks;
            JoypadCtrls = new List<JoypadController>();

            for (int i = 0; i < joypadsConnected.Length; i++)
            {
                if (i > 1)
                {
                    break;
                }

                //System.Console.WriteLine(joypadsConnected[i] + "pos: " + i);

                if (joypadsConnected[i] != null && joypadsConnected[i] != "Unmapped Controller")
                {
                    JoypadCtrls.Add(new PS4Controller(i));
                }
            }

            scene = new TitleScene();
        }

        public static void Run()
        {
            scene.Start();

            while (Window.IsOpened)
            {
                //System.Console.WriteLine("Mouse X: " + Window.MouseX + "\nMouse Y: " + Window.MouseY);

                //for (int i = 0; i < JoypadCtrls.Count; i++)
                //{
                //    System.Console.WriteLine(Window.JoystickDebug(i));
                //}

                if (scene.IsPlaying)
                {
                    if (Window.MouseX >= -7.911001f &&
                        Window.MouseX <= WindowWidth + 6.329f &&
                        Window.MouseY >= -27.37064f &&
                        Window.MouseY <= -0.7602956f &&
                        Window.MouseLeft &&
                        !Window.IsFullScreen())
                    {
                        Window.Update();
                        continue;
                    }

                    scene.Update();

                    //window update
                    Window.Update();
                }

                else
                {
                    scene.OnExit();

                    if (scene.NextScene != null)
                    {
                        scene = scene.NextScene;
                        scene.Start();
                    }

                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
