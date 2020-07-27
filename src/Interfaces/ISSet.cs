using System;

namespace Netsoft.OpenDataStructures.Interfaces
{
    public interface ISSet<T> where T : IEquatable<T>, IComparable<T>
    {
        int Size();

        void Add(T v);

        void Remove(T v);

        bool Find(T v);
    }
}