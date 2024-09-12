using System.Collections.Generic;

namespace SpaceShooter
{
    static class MoveMngr
    {
        private static List<IMovable> obj;

        static MoveMngr()
        {
            obj = new List<IMovable>();
        }

        public static void Add(IMovable item)
        {
            obj.Add(item);
        }

        public static void Remove(IMovable item)
        {
            obj.Remove(item);
        }

        public static void ClearAll()
        {
            obj.Clear();
        }

        public static void Move()
        {
            for (int i = 0; i < obj.Count; i++)
            {
                obj[i].Move();
            }
        }
    }
}
