using System;

namespace Netsoft.OpenDataStructures.Interfaces
{
    public interface IMyList<T> where T : IEquatable<T>
    {
        int Size();

        int Get(T i);

        void Set(int i, T v);

        void Add(int i, T v);

        void Remove(int i);
    }
}