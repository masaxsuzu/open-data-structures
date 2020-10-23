using System;
using System.Collections.Generic;
using System.Text;

namespace Netsoft.OpenDataStructures.Interfaces
{
    public interface IKVSet<T>
    {
        int Size();

        void Add(string k, T v);

        void Remove(string k);

        T Find(string k);

        bool Has(string k);
    }

}
