using System;
using System.Collections.Generic;
using System.Text;

namespace FischToolsLib.Utilies
{
    public static class ListTools
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static object RandomItem<T>(this IList<T> list)
        {
            int n = list.Count;
            var k = rng.Next(n);
            return list[k];
        }
    }
}
