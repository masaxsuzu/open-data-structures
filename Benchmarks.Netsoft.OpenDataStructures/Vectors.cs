using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using Netsoft.OpenDataStructures.Chapter02;

namespace Benchmarks.Netsoft.OpenDataStructures
{
    [MarkdownExporter, RPlotExporter]
    [SimpleJob(invocationCount: 50)]
    public class Vectors
    {
        private ArrayStack<int> _stack;
        private ArrayQueue<int> _queue;

        [Params(1, 10, 100, 1000, 10000)]
        public int N { get; set; }

        public Vectors()
        {
        }

        [GlobalSetup]
        public void Setup()
        {
            _stack = new ArrayStack<int>();
            _queue = new ArrayQueue<int>();

            for (int i = 0; i < N; i++)
            {
                _stack.Push(i);
            }

            for (int i = 0; i < N; i++)
            {
                _queue.Enqueue(i);
            }
        }

        [Benchmark]
        public void Stack()
        {
            for (int i = 0; i < 100000; i++)
            {
                _stack.Push(0);
                _ = _stack.Pop();
            }
        }

        [Benchmark]
        public void Queue()
        {
            for (int i = 0; i < 100000; i++)
            {
                _queue.Enqueue(0);
                _ = _queue.Dequeue();
            }
        }
    }
}
