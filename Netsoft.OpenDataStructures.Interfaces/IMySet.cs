using System;

namespace Netsoft.OpenDataStructures.Interfaces
{
    public interface IMySet<T> where T : IEquatable<T>
    {
        int Size();

        void Add(T v);

        void Remove(T v);

        bool Find(T v);
    }
}