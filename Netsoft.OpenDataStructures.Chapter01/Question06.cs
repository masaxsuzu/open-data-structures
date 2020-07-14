using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Netsoft.OpenDataStructures.Chapter01
{
    public class MyList
    {
        private int[] _collection;
        public MyList()
        {
            _collection = new int[0] { };
        }
        
        public int Size()
        {
           return  _collection.Length;
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

            for (int index = n - 1; index > i ; index--)
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

            Array.Resize(ref _collection, Size() -1);
        }
    }
}
