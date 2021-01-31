using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Netsoft.OpenDataStructures;

namespace Netsoft.OpenDataStructures.Chapter06
{
    public class Node<T>
    {
        public Node<T> Left {get;set;}
        public Node<T> Right {get;set;}
        public Node<T> Parent {get;set;}
        public T X {get; set;}
        public Node(T x) {
            X = x;
        }
    }
}
