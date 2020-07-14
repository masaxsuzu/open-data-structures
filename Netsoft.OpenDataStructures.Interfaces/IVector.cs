using System;

namespace Netsoft.OpenDataStructures.Interfaces
{
    public interface IVector<T> 
    {
        int Size();

        T Get(int i);

        void Set(int i, T v);

        void Add(int i, T v);

        void Remove(int i);
    }
}