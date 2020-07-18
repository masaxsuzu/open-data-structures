using System;

namespace Netsoft.OpenDataStructures.Chapter02
{
    public class ArrayDeque<T> : Interfaces.IVector<T>, Interfaces.IStack<T>, Interfaces.IQueue<T>
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

            return _a[Mod(_j + i)];
        }

        public T Set(int i, T v)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            var t = _a[Mod(_j + i)];
            _a[Mod(_j + i)] = v;
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

            if (i < _n / 2) 
            {
                _j = _j == 0 ? _a.Length - 1 : _j - 1;
                for (int k = 0; k < i - 1; k++)
                {
                    _a[Mod(_j + k)] = _a[Mod(_j + k + 1)];
                }
            } 
            else 
            {
                for (int k = _n; k > i; k--)
                {
                    _a[Mod(_j + k)] = _a[Mod(_j + k - 1)];
                }
            }

            _a[Mod(_j + i)] = v;
            _n++;
        }

        public T Remove(int i)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            var t = _a[Mod(_j + i)];

            if (i < _n / 2) 
            {
                for (int k = i; k > 0; k--)
                {
                    _a[Mod(_j + k)] = _a[Mod(_j + k - 1)];
                }
                _j = Mod(_j + 1);
            } 
            else
            {
                for (int k = i; k < _n - 1; k++)
                {
                    int dest = Mod(_j + k);
                    int src = Mod(_j + k + 1);
                    _a[dest] = _a[src];
                }
            }
            
            _n--;

            if (_a.Length >= 3 * _n)
            {
                Resize();
            }

            return t;
        }

        public void Push(T v)
        {
            Add(0, v);
        }

        public T Pop()
        {
            return Remove(0);
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
            int x = NextPow2(_n);
            Array.Resize(ref collection, Math.Max(x, 1));
            for (int i = 0; i < _n; i++)
            {
                int src = Mod(_j + i);
                collection[i] = _a[Mod(_j + i)];
            }

            _a = collection;
            _j = 0;
        }

        private int Mod(int r)
        {
            return r & (_a.Length - 1);
        }
        static int NextPow2(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            if ((n & (n - 1)) == 0)
            {
                return n * 2;
            }

            int ret = 1;
            while (n > 0) { ret <<= 1; n >>= 1; }
            return ret;
        }
    }
}
