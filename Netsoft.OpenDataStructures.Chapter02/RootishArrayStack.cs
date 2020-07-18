using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Netsoft.OpenDataStructures.Chapter02
{
    public class RootishArrayStack<T> : Interfaces.IVector<T>, Interfaces.IStack<T>
    {
        private readonly ArrayStack<T[]> _blocks;
        private int _n;

        public RootishArrayStack()
        {
            _blocks = new ArrayStack<T[]>();
            _n = 0;
        }

        public T Get(int i)
        {
            int b = GetBlockIndex(i);
            int j = i - b * (b + 1) / 2;
            return _blocks.Get(b)[j];
        }

        public T Set(int i, T v)
        {
            int b = GetBlockIndex(i);
            int j = i - b * (b + 1) / 2;
            var x = _blocks.Get(b)[j];
            _blocks.Get(b)[j] = v;
            return x;
        }

        public void Add(int i, T v)
        {
            int r = _blocks.Size();
            if (r * (r + 1) / 2 < _n + 1)
            {
                Grow();
            }
            
            _n++;

            for (int j = _n - 1; j > i; j--)
            {
                Set(j, Get(j - 1));
            }
            Set(i, v);
        }

        public T Remove(int i)
        {
            var x = Get(i);

            for (int j = i; j < _n - 1; j++)
            {
                Set(j, Get(j + 1));
            }

            _n--;

            int r = _blocks.Size();
            if((r - 2) * (r - 1) /2 >= _n)
            {
                Shrink();
            }
            return x;
        }

        public int Size()
        {
            return _n;
        }

        private void Grow()
        {
            _blocks.Add(_blocks.Size(), new T[_blocks.Size() + 1]);
        }

        private void Shrink()
        {
            int r = _blocks.Size();
            while (r > 0 && (r - 2) * (r - 1) / 2 >= _n)
            {
                _blocks.Remove(_blocks.Size() - 1);
                r--;
            }
        }

        private int GetBlockIndex(int i)
        {
            double x = (-3 + Math.Sqrt(9 + 8 * i)) / 2;
            return (int)Math.Ceiling(x);
        }

        public void Push(T v)
        {
            Add(_n, v);
        }

        public T Pop()
        {
            return Remove(_n - 1);
        }
    }
}