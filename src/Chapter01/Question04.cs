using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Netsoft.OpenDataStructures.Chapter01
{
    public static class Question04
    {
        public static IEnumerable<T> Answer<T>(Stack<T> @input)
        {
            var queue = new Queue<T>();
            while (input.Count > 0)
            {
                queue.Enqueue(input.Pop());
            }
            foreach (var item in queue)
            {
                input.Push(item);
            }

            return input;
        }
    }
    class MyStack<T> : IEnumerable<T>
    {
        private Queue<T> _q1;
        private Queue<T> _q2;

        public MyStack()
        {
            _q1 = new Queue<T>();
            _q2 = new Queue<T>();

            Count = 0;
        }

        public int Count { get; private set; }

        public T Pop()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException();
            }
            

            for (int i = 0; i < Count -1 ; i++)
            {
                _q2.Enqueue(_q1.Dequeue());
            }

            var item = _q1.Dequeue();

            // Swap queues
            var _ = _q2;
            _q2 = _q1;
            _q1 = _;

            Count--;

            return item;
        }

        public void Push(T item)
        {
            _q1.Enqueue(item);
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while(Count > 0)
            {
                yield return Pop();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
