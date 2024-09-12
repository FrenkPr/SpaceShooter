using System.Collections.Generic;

namespace SpaceShooter
{
    class OutOfScreenMngr
    {
        private static List<IOutOfScreen> obj;

        static OutOfScreenMngr()
        {
            obj = new List<IOutOfScreen>();
        }

        public static void Add(IOutOfScreen item)
        {
            obj.Add(item);
        }

        public static void Remove(IOutOfScreen item)
        {
            obj.Remove(item);
        }

        public static void ClearAll()
        {
            obj.Clear();
        }

        public static void CheckOutOfScreen()
        {
            for (int i = 0; i < obj.Count; i++)
            {
                obj[i].CheckOutOfScreen();
            }
        }
    }
}
