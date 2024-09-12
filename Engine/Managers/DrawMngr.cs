using System.Collections.Generic;

namespace SpaceShooter
{
    static class DrawMngr
    {
        private static List<IDrawable> drawings;

        static DrawMngr()
        {
            drawings = new List<IDrawable>();
        }

        public static void Add(IDrawable item)
        {
            drawings.Add(item);
        }

        public static void Remove(IDrawable item)
        {
            drawings.Remove(item);
        }

        public static void ClearAll()
        {
            drawings.Clear();
        }

        public static void Draw()
        {
            for (int i = 0; i < drawings.Count; i++)
            {
                drawings[i].Draw();
            }
        }
    }
}
