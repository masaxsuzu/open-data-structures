using System;

namespace Netsoft.OpenDataStructures.Chapter02
{
    public class DualArrayDeque<T> : Interfaces.IVector<T>, Interfaces.IStack<T>, Interfaces.IQueue<T>
    {
        private ArrayStack<T> _front;
        private ArrayStack<T> _back;
        public DualArrayDeque()
        {
            _front = new ArrayStack<T>();
            _back = new ArrayStack<T>();
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
                return _front.Get(_front.Size() - i - 1);
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
                return _front.Set(_front.Size() - i - 1, v);
            }
            else
            {
                return _back.Set(i - _front.Size() , v);
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
                 _front.Add(_front.Size() - i, v);
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
                ? _front.Remove(_front.Size() - i - 1)
                : _back.Remove(i - _front.Size());
            
            Balance();

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
            Add(Size(), v);
        }

        public T Dequeue()
        {
            return Remove(0);
        }

        private bool OutOfBounds(int i)
        {
            return i < 0 || Size() < i;
        }

        private void Balance()
        {
            if ((3 * _front.Size() < _back.Size()) ||
                 3 * _back.Size() < _front.Size())
            {
                int n = Size();
                
                int nf = n / 2;
                var af = new T[] { };
                Array.Resize(ref af, Math.Max(2*nf  , 1));

                for (int i = 0; i < nf; i++)
                {
                    af[nf - i - 1] = Get(i);
                }

                int nb = n - nf;
                var ab = new T[] { };
                Array.Resize(ref ab, Math.Max(2*nb, 1));

                for (int i = 0; i < nb; i++)
                {
                    ab[i] = Get(nf + i);
                }

                _front = new ArrayStack<T>(nf, af);
                _back = new ArrayStack<T>(nb, ab);
            }
        }
    }
}
