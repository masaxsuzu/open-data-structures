using System;
using System.Collections.Generic;
using System.Text;

namespace Netsoft.OpenDataStructures.Chapter01
{
    public class CheatList : Interfaces.IVector<int>
    {
        private readonly List<int> _list;
        public CheatList()
        {
            _list = new List<int>();
        }
        public void Add(int i, int v)
        {
            _list.Insert(i, v);
        }

        public int Get(int i)
        {
            return _list[i];
        }

        public void Remove(int i)
        {
            _list.RemoveAt(i);
        }

        public void Set(int i, int v)
        {
            _list[i] = v;
        }

        public int Size()
        {
            return _list.Count;
        }
    }
}
