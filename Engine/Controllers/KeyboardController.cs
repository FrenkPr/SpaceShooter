using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

namespace SpaceShooter
{
    class KeyboardController : Controller
    {
        public KeyboardController(int index) : base(index)
        {

        }

        public override float GetHorizontal()
        {
            float direction = 0;

            if (IsValuePressed(KeyCode.A) && IsValuePressed(KeyCode.D))
            {
                direction = 0;
            }

            else
            {
                if (IsValuePressed(KeyCode.A))
                {
                    direction = -1;
                }

                else if (IsValuePressed(KeyCode.D))
                {
                    direction = 1;
                }
            }

            return direction;
        }

        public override float GetVertical()
        {
            float direction = 0;

            if (IsValuePressed(KeyCode.W) && IsValuePressed(KeyCode.S))
            {
                direction = 0;
            }

            else
            {
                if (IsValuePressed(KeyCode.W))
                {
                    direction = -1;
                }

                else if (IsValuePressed(KeyCode.S))
                {
                    direction = 1;
                }
            }

            return direction;
        }

        public override bool IsFirePressed()
        {
            return IsValuePressed(KeyCode.Space);
        }

        public bool IsValuePressed(KeyCode value)
        {
            return Game.Window.GetKey(value);
        }
    }
}
