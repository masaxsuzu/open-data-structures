using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Netsoft.OpenDataStructures;

namespace Netsoft.OpenDataStructures.Chapter06
{

    public class BinaryTree<T>
    {
        public Node<T> Root {get; set;}
        
        public int Depth (Node<T> u)
        {
            int d = 0;
            while (Root != u)
            {
                u = u.Parent;
                d++;
            }
            return d;
        }

        public int Size(Node<T> u) 
        {
            if (u == null) {
                return 0;
            }
            return 1 + Size(u.Left) + Size(u.Right);
        }

        public int Height(Node<T> u)
        {
            if (u == null) {
                return 0;
            }
            return 1 + Math.Max(Height(u.Left),  Height(u.Right));
        }

        public IEnumerable<Node<T>> Traverse()
        {
            Node<T> u = Root;
            Node<T> prev = null;
            Node<T> next = null;

            while (u != null)
            {
                if (prev == u.Parent) {
                    yield return u;
                    if (u.Left != null) next = u.Left;
                    else if (u.Left != null) next = u.Right;
                    else next = u.Parent;
                }
                else if (prev == u.Left) {
                    if (u.Right != null) next = u.Right;
                    else next = u.Parent;
                }
                else {
                    next = u.Parent;
                }
                prev = u;
                u = next;
            }
        }
    }
}
