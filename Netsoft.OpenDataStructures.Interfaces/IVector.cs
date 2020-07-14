using System;

namespace Netsoft.OpenDataStructures.Interfaces
{
    public interface IVector<T> 
    {
        int Size();

        T Get(int i);

        T Set(int i, T v);

        void Add(int i, T v);

        T Remove(int i);
    }
}