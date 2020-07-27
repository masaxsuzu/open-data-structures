using System;
using System.Collections.Generic;
using System.Text;

namespace Netsoft.OpenDataStructures.Chapter02
{
    public class Vector<T> : Interfaces.IVector<T>
    {
        private T[] _collection;
        public Vector()
        {
            _collection = new T[0] { };
        }

        /// <summary>
        /// AddRange adds a collection of <typeparamref name="T"/>.
        /// 
        /// <paramref name="collection"/>[0] is added as <paramref name="i"/> th item.
        /// </summary>
        /// <remarks>
        /// This is much faster than calling <see cref="Add(int, T)"/> n times,
        /// </remarks>
        public void AddRange(int i, T[] collection)
        {
            int n = Size() + collection.Length;
            Array.Resize(ref _collection, n);

            for (int index = n - 1; index > i + collection.Length; index--)
            {
                _collection[index] = _collection[index - 1];
            }

            for (int index = 0; index < collection.Length; index++)
            {
                _collection[i + index] = collection[index];
            }
        }

        public int Size()
        {
            return _collection.Length;
        }

        public T Get(int i)
        {
            return _collection[i];
        }

        public T Set(int i, T v)
        {
            var t = _collection[i];
            _collection[i] = v;
            return t;
        }

        public void Add(int i, T v)
        {
            int n = Size() + 1;
            Array.Resize(ref _collection, n);

            for (int index = n - 1; index > i; index--)
            {
                _collection[index] = _collection[index - 1];
            }

            _collection[i] = v;
        }

        public T Remove(int i)
        {
            var t = _collection[i];
            for (int index = i; index < Size() - 1; index++)
            {
                _collection[index] = _collection[index + 1];
            }

            Array.Resize(ref _collection, Size() - 1);
            return t;
        }
    }
}
