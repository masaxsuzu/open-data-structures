using System;
using System.Collections.Generic;
using System.Text;

namespace Netsoft.OpenDataStructures.Chapter02
{
    public class RandomQueue<T> : Interfaces.IQueue<T>
    {
        private int _size;
        private T[] _collection;
        private readonly Random _rand;

        public RandomQueue(int seed)
        {
            _size = 0;
            _collection = new T[0] { };
            _rand = new Random(seed);
        }

        public int Size()
        {
            return _size;
        }

        public void Enqueue(T v)
        {
            if (_size >= _collection.Length)
            {
                Resize();
            }

            _collection[_size] = v;
            _size++;
        }

        public T Dequeue()
        {
            int i = _rand.Next(0, _size);
            var t = _collection[i];

            _collection[i] = _collection[_size - 1];
            _size--;

            if (_collection.Length >= 3 * _size)
            {
                Resize();
            }

            return t;
        }

        private bool OutOfBounds(int i)
        {
            return i < 0 || _size < i;
        }

        private void Resize()
        {
            var collection = new T[0] { };
            Array.Resize(ref collection, Math.Max(2 * _size, 1));
            for (int i = 0; i < _size; i++)
            {
                collection[i] = _collection[i];
            }

            _collection = collection;
        }
    }
}
