using System;
using Netsoft.OpenDataStructures;

namespace Netsoft.OpenDataStructures.Chapter03
{
    public class SLList<T> : Interfaces.IStack<T>, Interfaces.IQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _size;
        public SLList()
        {
            _size = 0;
        }

        public T Dequeue()
        {
            return Pop();
        }

        public void Enqueue(T v)
        {
            var u = new Node<T>() {
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

            T x = _head.Value;
            _head = _head.Next;

            _size--;
            if(_size == 0) {
                _tail = null;
            }

            return x;
        }

        public void Push(T v)
        {
            var u = new Node<T>() {
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
