using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaChop.DataStructures
{
    public sealed class Cons<T> : IEnumerable<T>
    {
        public readonly int Length;
        public readonly T Head;
        public readonly Cons<T> Tail;



        public bool IsEmpty => Length == 0;



        public Cons<T> Add(T item)
        {
            return new Cons<T>(Length + 1, item, this);
        }

        public Cons<T> Remove(T item)
        {
            Stack<T> acc = new Stack<T>();
            Cons<T> curr = this;
            while (!curr.IsEmpty)
            {
                if (EqualityComparer<T>.Default.Equals(curr.Head, item))
                {
                    while (acc.Count != 0)
                        curr = new Cons<T>(curr.Tail.Length + 1, acc.Pop(), curr.Tail);
                    return curr;
                }

                acc.Push(curr.Head);
                curr = curr.Tail;
            }
            return this;
        }



        public Cons(IEnumerable<T> enumerable)
        {
            var list = new Cons<T>();
            foreach (T item in enumerable)
                list = new Cons<T>(list.Length + 1, item, list);

            Length = list.Length;
            Head = list.Head;
            Tail = list.Tail;
        }

        public Cons() { }

        private Cons(int length, T head, Cons<T> tail)
        {
            Length = length;
            Head = head;
            Tail = tail;
        }



        public IEnumerator<T> GetEnumerator()
        {
            var list = this;
            while (!list.IsEmpty)
            {
                yield return list.Head;
                list = list.Tail;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
