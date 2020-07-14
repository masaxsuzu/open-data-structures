using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Netsoft.OpenDataStructures.Chapter01
{
    public class MyList : Interfaces.IMyList<int>
    {
        private int[] _collection;
        public MyList()
        {
            _collection = new int[0] { };
        }

        public int Size()
        {
            return _collection.Length;
        }

        public int Get(int i)
        {
            return _collection[i];
        }

        public void Set(int i, int v)
        {
            _collection[i] = v;
        }

        public void Add(int i, int v)
        {
            int n = Size() + 1;
            Array.Resize(ref _collection, n);

            for (int index = n - 1; index > i; index--)
            {
                _collection[index] = _collection[index - 1];
            }

            _collection[i] = v;
        }

        public void Remove(int i)
        {

            for (int index = i; index < Size() - 1; index++)
            {
                _collection[index] = _collection[index + 1];
            }

            Array.Resize(ref _collection, Size() - 1);
        }
    }
    public class MySSet : Interfaces.IMySSet<int>
    {
        private int[] _collection;
        public MySSet()
        {
            _collection = new int[0] { };
        }

        public int Size()
        {
            return _collection.Length;
        }

        public void Add(int v)
        {
            if (_collection.Contains(v))
            {
                return;
            }
            int n = Size() + 1;
            Array.Resize(ref _collection, n);
            _collection[n - 1] = v;
        }

        public void Remove(int v)
        {
            int i = -1;
            for (int index = 0; index < Size(); index++)
            {
                if (_collection[index] == v)
                {
                    i = index;
                    break;
                }
            }

            if (i == -1)
            {
                return;
            }

            for (int index = i; index < Size() - 1; index++)
            {
                _collection[index] = _collection[index + 1];
            }

            Array.Resize(ref _collection, Size() - 1);
        }


        public bool Find(int x)
        {
            return _collection.Contains(x);
        }
    }

    public class MyUSet : Interfaces.IMyUSet<int>
    {
        private int[] _collection;
        public MyUSet()
        {
            _collection = new int[0] { };
        }

        public int Size()
        {
            return _collection.Length;
        }

        public void Add(int v)
        {
            if (_collection.Contains(v))
            {
                return;
            }
            int n = Size() + 1;
            Array.Resize(ref _collection, n);
            _collection[n - 1] = v;
            Array.Sort(_collection);
        }

        public void Remove(int v)
        {
            int i = -1;
            for (int index = 0; index < Size(); index++)
            {
                if (_collection[index] == v)
                {
                    i = index;
                    break;
                }
            }

            if (i == -1)
            {
                return;
            }

            for (int index = i; index < Size() - 1; index++)
            {
                _collection[index] = _collection[index + 1];
            }

            Array.Resize(ref _collection, Size() - 1);
            Array.Sort(_collection);
        }


        public bool Find(int x)
        {
            for (int i = 0; i < Size(); i++)
            {
                if(_collection[i] >= x)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
