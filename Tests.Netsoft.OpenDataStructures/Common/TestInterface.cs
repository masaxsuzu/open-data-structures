using Netsoft.OpenDataStructures.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Common
{
    public class TestInterface
    {
        internal static void TestVector(IVector<int> list)
        {
            Assert.Equal(0, list.Size());

            list.Add(0, 1);
            list.Add(0, 2);
            list.Add(0, 3);
            Assert.Equal(1, list.Get(2));
            Assert.Equal(2, list.Get(1));
            Assert.Equal(3, list.Get(0));

            list.Remove(0);

            Assert.Equal(1, list.Get(1));
            Assert.Equal(2, list.Get(0));

            list.Add(1, 5);
            list.Add(1, 6);

            Assert.Equal(1, list.Get(3));
            Assert.Equal(5, list.Get(2));
            Assert.Equal(6, list.Get(1));
            Assert.Equal(2, list.Get(0));

            list.Set(3, 13);
            list.Set(2, 12);
            list.Set(1, 11);
            list.Set(0, 10);

            Assert.Equal(13, list.Get(3));
            Assert.Equal(12, list.Get(2));
            Assert.Equal(11, list.Get(1));
            Assert.Equal(10, list.Get(0));
        }

        internal static void TestStack(IStack<int> stack)
        {
            var got = new List<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            got.Add(stack.Pop());
            got.Add(stack.Pop());
            got.Add(stack.Pop());

            Assert.Equal(new int[] { 3, 2, 1 }, got);
        }

        internal static void TestQueue(IQueue<int> queue)
        {
            var got = new List<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            got.Add(queue.Dequeue());
            got.Add(queue.Dequeue());
            got.Add(queue.Dequeue());

            Assert.Equal(new int[] { 1, 2, 3 }, got);
        }
    }
}
