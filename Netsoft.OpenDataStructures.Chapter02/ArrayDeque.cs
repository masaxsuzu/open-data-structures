using System;

namespace Netsoft.OpenDataStructures.Chapter02
{
    public class ArrayDeque<T> : Interfaces.IVector<T>, Interfaces.IQueue<T>
    {
        private int _n;
        private int _j;
        private T[] _a;
        public ArrayDeque()
        {
            _n = 0;
            _a = new T[0] { };
        }

        public int Size()
        {
            return _n;
        }

        public T Get(int i)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            return _a[(_j + i) % _a.Length];
        }

        public T Set(int i, T v)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            var t = _a[(_j + i) % _a.Length];
            _a[(_j + i) % _a.Length] = v;
            return t;
        }

        public void Add(int i, T v)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            if (_n + i >= _a.Length)
            {
                Resize();
            }

            if (i < _n / 2) {
                _j = _j == 0 ? _a.Length - 1 : _j - 1;
                for (int k = 0; k < i - 1; k++)
                {
                    _a[(_j + k) % _a.Length] = _a[(_j + k + 1) % _a.Length]; 
                }
            } else {
                for (int k = _n; k > i; k--)
                {
                    _a[(_j + k) % _a.Length] = _a[(_j + k - 1) % _a.Length];
                }
            }

            _a[(_j + i) % _a.Length ] = v;
            _n++;
        }

        public T Remove(int i)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            var t = _a[(_j + i) % _a.Length];

            if (i < _n / 2) {
                for (int k = i; k > 0; k--)
                {
                    _a[(_j + k) % _a.Length] = _a[(_j + k - 1) % _a.Length];
                }
                _j = (_j + 1) % _a.Length;
            } else {
                for (int k = i; k < _n - 1; k++)
                {
                    _a[(_j + k) % _a.Length] = _a[(_j + k + 1) % _a.Length]; 
                }
            }
            
            _n--;

            if (_a.Length >= 3 * _n)
            {
                Resize();
            }

            return t;
        }

        public void Enqueue(T v)
        {
            Add(_n, v);
        }

        public T Dequeue()
        {
            return Remove(0);
        }

        private bool OutOfBounds(int i)
        {
            return i < 0 || _n < i;
        }

        private void Resize()
        {
            var collection = new T[0] { };
            Array.Resize(ref collection, Math.Max(2 * _n, 1));
            for (int i = 0; i < _n; i++)
            {
                collection[i] = _a[(_j + i) % _a.Length];
            }

            _a = collection;
            _j = 0;
        }
    }
}
