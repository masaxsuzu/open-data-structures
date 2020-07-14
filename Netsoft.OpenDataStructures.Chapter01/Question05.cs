using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Netsoft.OpenDataStructures.Chapter01
{
    public class Bag
    {
        private readonly SortedSet<BagKey<int>> _set;
        public Bag()
        {
            _set = new SortedSet<BagKey<int>>();
        }

        public void Add(int item)
        {
            var key = new BagKey<int>(item, 0);
            var actual = new BagKey<int>(item, 0);
            if (_set.Contains(new BagKey<int>(item, 0)))
            {
                _set.TryGetValue(key, out actual);
                _set.Remove(key);
            }
            _set.Add(new BagKey<int>(item, actual.Value + 1));
        }

        public bool Remove(int item)
        {
            var key = new BagKey<int>(item, 0);
            if (_set.Contains(new BagKey<int>(item, 0)))
            {
                _set.TryGetValue(key, out var actual);
                _set.Remove(key);
                _set.Add(new BagKey<int>(item, actual.Value > 0 ? actual.Value - 1 : 0));
                return true;
            }
            return false;
        }

        public bool Find(int item)
        {
            return FindAll(item) > 0;
        }

        public int FindAll(int item)
        {
            var key = new BagKey<int>(item, 0);
            if (_set.Contains(new BagKey<int>(item, 0)))
            {
                _set.TryGetValue(key, out var actual);
                return actual.Value;
            }

            return 0;
        }
    }

    class BagKey<V> : IComparable
    {
        private readonly int _key;

        public BagKey(int key, V value)
        {
            _key = key;
            Value = value;
        }

        public V Value { get; }
        public int CompareTo(object obj)
        {
            if (obj is BagKey<V> key)
            {
                return _key.CompareTo(key._key);
            }

            return -1;
        }
    }
}
