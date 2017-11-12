using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaChop
{
    public static class Extensions
    {

        public static IEnumerable<T> Map<T>(this IEnumerable<T> enumerable, Func<T, T> func)
        {
            List<T> output = new List<T>();
            foreach (T item in enumerable)
                output.Add(func.Invoke(item));
            return output;
        }



        public static T[] Map<T>(this T[] array, Func<T, T> func)
        {
            T[] output = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
                output[i] = func.Invoke(array[i]);
            return output;
        }
        public static T[] pMap<T>(this T[] array, Func<T, T> func)
        {
            T[] output = new T[array.Length];
            Action<int> body = i => output[i] = func.Invoke(array[i]);
            Parallel.For(0, array.Length, body);
            return output;
        }




        public static List<T> Map<T>(this List<T> list, Func<T, T> func)
        {
            T[] array = new T[list.Count];
            for (int i = 0; i < list.Count; i++)
                array[i] = func.Invoke(list[i]);
            return new List<T>(array);
        }

        public static List<T> pMap<T>(this List<T> list, Func<T, T> func)
        {
            T[] array = new T[list.Count];
            Action<int> body = i => array[i] = func.Invoke(list[i]);
            Parallel.For(0, list.Count, body);
            return new List<T>(array);
        }




        public static T[] Filter<T>(this T[] array, Predicate<T> pred)
        {
            List<T> filtered = new List<T>();
            foreach (T item in array)
                if (pred.Invoke(item))
                    filtered.Add(item);
            return filtered.ToArray();
        }

        /// <summary>
        /// Returns a new array with only elements from the original array
        /// that satisfy the predicate, not necessarily in the same order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public static T[] pFilter<T>(this T[] array, Predicate<T> pred)
        {
            ConcurrentStack<T> filtered = new ConcurrentStack<T>();
            Action<T> body = item =>
            {
                if (pred.Invoke(item))
                    filtered.Push(item);
            };
            Parallel.ForEach(array, body);
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

        /// <summary>
        /// Returns a new array with only elements from the original array
        /// that satisfy the predicate, not necessarily in the same order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public static List<T> pFilter<T>(this List<T> list, Predicate<T> pred)
        {
            ConcurrentStack<T> filtered = new ConcurrentStack<T>();
            Parallel.ForEach(list, item =>
            {
                if (pred.Invoke(item))
                    filtered.Push(item);
            });
            return filtered.ToList();
        }




        public static Func<Input, Output> Memoize<Input, Output>(this Func<Input, Output> func)
        {
            Dictionary<Input, Output> cache = new Dictionary<Input, Output>();
            return x =>
            {
                if (!cache.ContainsKey(x))
                    cache.Add(x, func.Invoke(x));
                return cache[x];
            };
        }

        public static Func<Output> Prep<Input, Output>(this Func<Input, Output> func, Input param)
        {
            return () => func.Invoke(param);
        }

        public static Func<Input2, Output> Prep<Input1, Input2, Output>(this Func<Input1, Input2, Output> func, Input1 param1)
        {
            return x => func.Invoke(param1, x);
        }
    }
}
