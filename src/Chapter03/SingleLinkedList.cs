using System;
using Netsoft.OpenDataStructures;

namespace Netsoft.OpenDataStructures.Chapter03
{
    public class SingleLinkedList<T> : Interfaces.IStack<T>, Interfaces.IQueue<T>
    {
        private class Node
        {
            public Node()
            {
            }
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        private Node _head;
        private Node _tail;
        private int _size;
        public SingleLinkedList()
        {
            _size = 0;
        }

        public T Dequeue()
        {
            return Pop();
        }

        public void Enqueue(T v)
        {
            var u = new Node() {
                Value = v,
            };
            if(_size == 0) {
                _head = u;
            } else {
                _tail.Next = u;
            }

            _tail = u;
            _size++;
        }

        public T Pop()
        {
            if (_size == 0) {
                throw new InvalidOperationException();
            }

            var x = _head.Value;
            _head = _head.Next;

            _size--;
            if(_size == 0) {
                _tail = null;
            }

            return x;
        }

        public void Push(T v)
        {
            var u = new Node() {
                Value = v,
                Next = _head,
            };

            u.Next = _head;
            _head = u;

            if (_size == 0) {
                _tail = _head;
            }

            _size++;
        }

        public int Size()
        {
            return _size;
        }
    }
}
