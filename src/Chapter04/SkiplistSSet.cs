using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Netsoft.OpenDataStructures;

namespace Netsoft.OpenDataStructures.Chapter04
{
    public class SkiplistSSet<T> : Interfaces.ISSet<T> where T : IEquatable<T>, IComparable<T>
    {
        private const int MaxLevel = 20;
        private readonly Random _random;
        private readonly SkipListSetNode _head;
        private readonly SkipListSetNode _nil;

        private int _version = 0;
        private int _level = 0;
        private int _count = 0;
        public SkiplistSSet() {
            _random = new Random();
            _head = new SkipListSetNode(default(T), MaxLevel);
            _nil = _head;
            _version = 0;

            for (var i = 0; i <= MaxLevel; i++)
            {
                _head.Forward[i] = _nil;
            }
        }

        public bool Find(T v)
        {
            var u = Search(v);
            return u == null ? false : u.Key.CompareTo(v) == 0;
        }

        public void Add(T key)
        {            
            var updateList = new SkipListSetNode[MaxLevel + 1];
            var node = _head;
            for (var i = _level; i >= 0; i--)
            {
                while (node.Forward[i] != _nil && node.Forward[i].Key.CompareTo(key) < 0)
                {
                    node = node.Forward[i];
                }
                updateList[i] = node;
            }
            node = node.Forward[0];
            if (node != _nil && node.Key.CompareTo(key) == 0)
            {
                return;
            }

            var newLevel = 0;
            for (; _random.Next(0, 2) > 0 && newLevel < MaxLevel; newLevel++) ;
            if (newLevel > _level)
            {
                for (var i = _level + 1; i <= newLevel; i++)
                {
                    updateList[i] = _head;
                }
                _level = newLevel;
            }

            node = new SkipListSetNode(key, newLevel);

            for (var i = 0; i <= newLevel; i++)
            {
                node.Forward[i] = updateList[i].Forward[i];
                updateList[i].Forward[i] = node;
            }
            _count++;
            _version++;
        }

        public void Remove(T key)
        {
            var updateList = new SkipListSetNode[MaxLevel + 1];
            var node = _head;
            for (var i = _level; i >= 0; i--)
            {
                while (node.Forward[i] != _nil && node.Forward[i] .Key.CompareTo(key) < 0)
                {
                    node = node.Forward[i];
                }
                updateList[i] = node;
            }
            node = node.Forward[0];
            // /X

            if (node == _nil || node.Key.CompareTo(key) != 0)
            {
                return;
            }

            for (var i = 0; i <= _level; i++)
            {
                if (updateList[i].Forward[i] != node)
                {
                    break;
                }
                updateList[i].Forward[i] = node.Forward[i];
            }
            while (_level > 0 && _head.Forward[_level] == _nil)
            {
                _level--;
            }
            _count--;
            _version++;
            return;
        }

        public int Size()
        {
            return _count;
        }

        private SkipListSetNode Search(T key)
        {
            var node = _head;

            for (var i = _level; i >= 0; i--)
            {
                while (node.Forward[i] != _nil)
                {
                    var cmpResult = node.Forward[i].Key.CompareTo(key);
                    if (cmpResult > 0)
                    {
                        break;
                    }
                    if (cmpResult == 0)
                    {
                        return node.Forward[i];
                    }
                    node = node.Forward[i];
                }
            }

            return node;
        }

        internal class SkipListSetNode
        {
            public SkipListSetNode(T key, int level)
            {
                Key = key;
                Forward = new SkipListSetNode[level + 1];
            }

            public T Key { get; private set; }

            public SkipListSetNode[] Forward { get; private set; }
        }
    }
}