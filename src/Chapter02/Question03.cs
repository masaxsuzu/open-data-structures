using System;
using System.Collections.Generic;
using System.Text;

namespace Netsoft.OpenDataStructures.Chapter02
{
    public class Treque<T> : Interfaces.IVector<T>
    {
        private readonly ArrayDeque<T> _front;
        private readonly ArrayDeque<T> _back;
        public Treque()
        {
            _front = new ArrayDeque<T>();
            _back = new ArrayDeque<T>();
        }

        public int Size()
        {
            return _front.Size() + _back.Size();
        }

        public T Get(int i)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            if (i < _front.Size())
            {
                return _front.Get(i);
            }
            else
            {
                return _back.Get(i - _front.Size());
            }
        }

        public T Set(int i, T v)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            if (i < _front.Size())
            {
                return _front.Set(i, v);
            }
            else
            {
                return _back.Set(i - _front.Size(), v);
            }
        }

        public void Add(int i, T v)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            if (i < _front.Size())
            {
                _front.Add(i, v);
            }
            else
            {
                _back.Add(i - _front.Size(), v);
            }

            Balance();
        }

        public T Remove(int i)
        {
            if (OutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }

            var t = i < _front.Size()
                ? _front.Remove(i)
                : _back.Remove(i - _front.Size());

            Balance();
            
            return t;
        }

        private void Balance()
        {

            if (_front.Size() == _back.Size() + 2)
            {
                _back.Add(0, _front.Remove(_front.Size() - 1));
            }
            else if (_back.Size() == _front.Size() + 2)
            {
                _front.Add(_front.Size(), _back.Remove(0));
            }
        }

        private bool OutOfBounds(int i)
        {
            return i < 0 || Size() < i;
        }
    }
}