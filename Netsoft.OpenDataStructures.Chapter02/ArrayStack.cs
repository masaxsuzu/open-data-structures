using System;

namespace Netsoft.OpenDataStructures.Chapter02
{
    public class ArrayStack<T> : Interfaces.IVector<T>, Interfaces.IStack<T>
    {
        private int _size;
        private T[] _collection;
        public ArrayStack()
        {
            _size = 0;
            _collection = new T[0] { };
        }

        public ArrayStack(int size, T[] collection)
        {
            _size = size;
            _collection = collection;
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

            return  _collection[i];
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

            if(_size + i >= _collection.Length)
            {
                Resize();
            }

            for (int index = _size; index  > i; index--)
            {
                _collection[index] = _collection[index - 1];
            }

            _collection[i] = v;

            _size++;
        }

        public T Remove(int i)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            var t = _collection[i];

            for (int index = i;  index < _size - 1;  index++)
            {
                _collection[index] = _collection[index + 1];
            }

            _size--;

            if(_collection.Length >= 3 * _size)
            {
                Resize();
            }

            return t;
        }

        public void Push(T v)
        {
            Add(_size, v);
        }

        public T Pop()
        {
            return Remove(_size - 1);
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
