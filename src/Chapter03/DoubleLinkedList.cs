using System;
using Netsoft.OpenDataStructures;

namespace Netsoft.OpenDataStructures.Chapter03
{
    public class DoubleLinkedList<T> : Interfaces.IVector<T>
    {
        private class Node
        {
            public Node()
            {
            }
            public T Value { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }
        }

        private Node _dummy;
        private int _size;
        public DoubleLinkedList()
        {
            _dummy = new Node();
            _dummy.Next = _dummy;
            _dummy.Previous = _dummy;
            _size = 0;
        }

        public int Size()
        {
            return _size;
        }

        public T Get(int i)
        {
            return TraverseNode(i).Value;
        }

        public T Set(int i, T v)
        {
            var x = TraverseNode(i);
            var y = x.Value;
            x.Value = v;
            return y;
        }

        public void Add(int i, T v)
        {
            AddBefore(TraverseNode(i), v);
        }

        private Node AddBefore(Node w, T v) {
            Node node = new Node();
            node.Value = v;
            node.Previous = w.Previous;
            node.Next = w;
            node.Next.Previous = node;
            node.Previous.Next = node;
            _size++;
            return node;
        }

        public T Remove(int i)
        {
            Node node = TraverseNode(i);
            var x = node.Value;
            Remove(node);
            return x;
        }
        
        private void Remove(Node w) {
            w.Previous.Next = w.Next;
            w.Next.Previous = w.Previous;
            _size--;
        }

        private Node TraverseNode(int i) {
            Node node;
            if( i < _size/2) {
                node = _dummy.Next;
                for (int j = 0; j < i; j++)
                {
                    node = node.Next;
                }
            } else {
                node = _dummy;
                for (int j = _size; j > i; j--)
                {
                    node = node.Previous;
                }
            }
            return node;
        }
    }
}
