using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaChop
{
    public static class Extensions
    {
        public static T[] Map<T>(this T[] array, Func<T, T> func)
        {
            T[] output = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
                output[i] = func.Invoke(array[i]);
            return output;
        }

        public static List<T> Map<T>(this List<T> list, Func<T, T> func)
        {
            List<T> output = new List<T>(list.Count);
            for (int i = 0; i < list.Count; i++)
                output[i] = func.Invoke(list[i]);
            return output;
        }



        public static T[] Filter<T>(this T[] array, Predicate<T> pred)
        {
            List<T> filtered = new List<T>();
            foreach (T item in array)
                if (pred.Invoke(item))
                    filtered.Add(item);
            return filtered.ToArray();
        }

        public static List<T> Filter<T>(this List<T> list, Predicate<T> pred)
        {
            List<T> filtered = new List<T>();
            foreach (T item in list)
                if (pred.Invoke(item))
                    filtered.Add(item);
            return filtered;
        }
    }
}
