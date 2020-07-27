using System;
using System.Collections.Generic;
using System.Text;

namespace Netsoft.OpenDataStructures.Interfaces
{
    public interface IStack<T> 
    {
        int Size();
        void Push(T v);
        T Pop();   
    }
}
