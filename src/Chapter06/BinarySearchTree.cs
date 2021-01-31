using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Netsoft.OpenDataStructures;

namespace Netsoft.OpenDataStructures.Chapter06
{
    public class BinarySearchTree<T> : Interfaces.ISSet<T>
        where T : IEquatable<T>, IComparable<T>
    {
        private Node<T> R {get; set;}
        private int N {get; set;}

        public int Size() => N;

        public bool Find(T x)
        {
            var u = FindNode(x);
            return u != null;
        }
        private Node<T> FindNode(T x){
            var w = R;
            while (w != null)
            {
                int comp = x.CompareTo(w.X);
                if (comp < 0) w = w.Left;
                else if (comp > 0) w = w.Right;
                else return w;
            }
            return null;
        }

        private Node<T> FindLast(T x){
            var w = R;
            Node<T> prev = null;
            while (w != null)
            {
                prev = w;
                int comp = x.CompareTo(w.X);
                if (comp < 0) w = w.Left;
                else if (comp > 0) w = w.Right;
                else return w;
            }
            return prev;
        }

        public void Add(T x)
        {
            var p = FindLast(x);
            var u = new Node<T>(x);
            AddChild(p, u);
        }

        private bool AddChild(Node<T> p, Node<T> u)
        {
            if (p == null)
            {
                R = u;
            }
            else {
                int comp = u.X.CompareTo(p.X);
                if (comp < 0) p.Left = u;
                else if (comp > 0) p.Right = u;
                else return false;

                u.Parent = p;
            }
            N++;
            return true;
        }
    
        public void Remove(T x) {
            var u = FindNode(x);
            if (u == null) return;
            if (u.Left == null || u.Right == null) {
                Splice(u);
            } else {
                Node<T> w = u.Right;
                while (w.Left != null) {
                    w = w.Left;
                }
                u.X = w.X;
                Splice(w);
            }
        }

        private void Splice(Node<T> u)
        {
            if (u == null) return;
            Node<T> s, p = null;

            if (u.Left != null)
                s = u.Left;
            else
                s = u.Right;

            if (u == R) {
                R = s;
                p = null;
            }
            else {
                p = u.Parent;
                if (p.Left == u) 
                    p.Left = s;
                else
                    p.Right = s;
            }
            
            if (s != null) {
                s.Parent = p;
            }
            N--;
        }
    }
}

