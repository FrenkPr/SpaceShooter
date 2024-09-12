using System.Collections.Generic;

namespace SpaceShooter
{
    static class ShootMngr
    {
        private static List<IShootable> obj;

        static ShootMngr()
        {
            obj = new List<IShootable>();
        }

        public static void Add(IShootable item)
        {
            obj.Add(item);
        }

        public static void Remove(IShootable item)
        {
            obj.Remove(item);
        }

        public static void ClearAll()
        {
            obj.Clear();
        }

        public static void Shoot()
        {
            for (int i = 0; i < obj.Count; i++)
            {
                obj[i].Shoot();
            }
        }
    }
}
