using System;
using Netsoft.OpenDataStructures;

namespace Netsoft.OpenDataStructures.Chapter03
{
    public class Node<T> {
        
        public Node() {
        }

        public T Value {get; set;}
        public Node<T> Next { get; set;}
    }
}