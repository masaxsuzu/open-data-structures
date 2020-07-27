using System;

namespace Netsoft.OpenDataStructures.Chapter02
{
    public class ArrayQueue<T> : Interfaces.IQueue<T>
    {
        private int _size;
        private int _current;
        private T[] _collection;
        public ArrayQueue()
        {
            _size = 0;
            _collection = new T[0] { };
        }

        public int Size()
        {
            return _size;
        }

        public T Get(int i)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            return _collection[i];
        }

        public T Set(int i, T v)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            var t = _collection[i];
            _collection[i] = v;
            return t;
        }

        public void Add(int i, T v)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            if (_size + i >= _collection.Length)
            {
                Resize();
            }

            _collection[(_current + _size) % _collection.Length ] = v;
            _size++;
        }

        public T Remove(int i)
        {
            var t = _collection[i];

            _current = (_current + 1) % _collection.Length;

            _size--;

            if (_collection.Length >= 3 * _size)
            {
                Resize();
            }

            return t;
        }

        public void Enqueue(T v)
        {
            Add(0, v);
        }

        public T Dequeue()
        {
            return Remove(_current);
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
                collection[i] = _collection[(_current + i) % _collection.Length];
            }

            _collection = collection;
            _current = 0;
        }
    }
}
