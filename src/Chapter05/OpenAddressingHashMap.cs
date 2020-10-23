using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Netsoft.OpenDataStructures;

namespace Netsoft.OpenDataStructures.Chapter05
{
    public class OpenAddressingHashMap<T> : Interfaces.IKVSet<T>
    {
        public class HashEntry
        {
            public string Key {get; set;}
            public T Value {get; set;}
            public bool isDead {get; set;}
            public uint Hash {get ;set;}
        }

        private const int InitialSize = 16;
        private const int HighWaterMark = 70;
        private const int LowWaterMark = 50;

        private HashEntry[] _bucket;
        private int _capacity;
        private int _size;

        public OpenAddressingHashMap(): this(InitialSize)
        {
        }

        private OpenAddressingHashMap(int cap)
        {
            _capacity = cap;
            _bucket = new HashEntry[_capacity];
        }

        public int Size() 
        {
            return _size;
        }

        public void Add(string k, T v) 
        {
            Put(k, v);
        }

        public void Remove(string k)
        {
            if(!Has(k))
            {
                return;
            }

            var entry = Get(k);
            if(entry != null)
            {
                entry.isDead = true;
            }
        }

        public T Find(string k)
        {
            uint hash = ComputeFnvHash(k);
            for (int i = 0; i < _capacity; i++)
            {
                var index = (hash + i) % _capacity;
                var entry = _bucket[index];
                if (Match(entry, k)) 
                {
                    return entry.Value;
                }
            }
            throw new KeyNotFoundException();
        }

        public bool Has(string k)
        {
            uint hash = ComputeFnvHash(k);

            for (int i = 0; i < _capacity; i++)
            {
                var index = (hash + i) % _capacity;
                var entry = _bucket[index];
                if (Match(entry, k)) 
                {
                    return true;
                }
            }
            return false;
        }

        private HashEntry Get(string key)
        {
            uint hash = ComputeFnvHash(key);

            for (int i = 0; i < _capacity; i++)
            {
                var index = (hash + i) % _capacity;
                var entry = _bucket[index];
                if (Match(entry, key))
                {
                    return entry;
                }

                if(entry == null)
                {
                    return null;
                }
            }

            throw new KeyNotFoundException("unreachable");
        }
        private HashEntry GetOrInsert(string key)
        {
            if(_size * 100 / _capacity >= HighWaterMark)
            {
                ReHash();
            }

            uint hash = ComputeFnvHash(key);

            for (int i = 0; i < _capacity; i++)
            {
                var index = (hash + i) % _capacity;
                var entry = _bucket[index];
                if (Match(entry, key))
                {
                    return entry;
                }

                if(entry != null && entry.isDead)
                {
                    entry.Key = key;
                    entry.isDead = false;
                    return entry;
                }

                if(entry == null)
                {
                    entry = new HashEntry()
                    {
                        Key = key
                    };
                    _bucket[index] = entry;
                    entry.Hash = hash;
                    _size++;
                    return entry;
                }
            }

            throw new KeyNotFoundException("unreachable");
        }

        private void Put(string key, T value)
        {
            var e = GetOrInsert(key);
            e.Value = value;
        }

        private bool Match(HashEntry entry, string key)
        {
            return 
                entry != null && !entry.isDead && entry.Key == key;
        }

        private void ReHash()
        {
            int nKeys = Enumerable
                .Range(0, _capacity)
                .Where(i => _bucket[i] != null && !_bucket[i].isDead)
                .Count();

            int cap = _capacity;
            while ((nKeys * 100) / cap >= LowWaterMark)
            {
                cap = cap *2;
            }

            if(cap <= 0) {
                throw new Exception("cap <= 0");
            }

            var newHashMap = new OpenAddressingHashMap<T>(cap);

            for (int i = 0; i < _capacity; i++)
            {
                var entry = _bucket[i];
                if(entry != null && !entry.isDead)
                {
                    newHashMap.Put(entry.Key, entry.Value);
                }
            }

            _bucket = newHashMap._bucket;
            _capacity = newHashMap._capacity;
            _size = newHashMap._size;
            if(nKeys != _size) {
                throw new Exception("nKeys != _size");
            }
        }

        uint ComputeFnvHash(string k)
        {
            int len = k.Length;
            uint hash = 2166136261U;
            for (int i = 0; i < len; i++)
            {
                hash *= 16777619U;
                hash ^= k[i];
            }
            return hash;
        }
    }
}
