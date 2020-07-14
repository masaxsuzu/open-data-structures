using System;
using System.Collections.Generic;
using System.Text;

namespace Netsoft.OpenDataStructures.Interfaces
{
    public interface IQueue<T> 
    {
        int Size();
        void Enqueue(T v);
        T Dequeue();   
    }
}
