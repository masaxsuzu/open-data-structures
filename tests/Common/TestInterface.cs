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

            list.Remove(2);
            list.Remove(1);

            Assert.Equal(13, list.Get(1));
            Assert.Equal(10, list.Get(0));
        }

        internal static void TestStack(IStack<int> stack)
        {
            var got = new List<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            got.Add(stack.Pop());
            got.Add(stack.Pop());
            got.Add(stack.Pop());
            got.Add(stack.Pop());
            got.Add(stack.Pop());
            got.Add(stack.Pop());

            Assert.Equal(new int[] { 6, 5, 4, 3, 2, 1 }, got);
        }

        internal static void TestQueue(IQueue<int> queue)
        {
            var got = new List<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            got.Add(queue.Dequeue());
            got.Add(queue.Dequeue());
            got.Add(queue.Dequeue());
            got.Add(queue.Dequeue());
            got.Add(queue.Dequeue());
            got.Add(queue.Dequeue());

            Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6 }, got);
        }

        internal static void TestSSet(ISSet<int> set)
        {
            Assert.Equal(0, set.Size());

            set.Add(1);
            set.Add(2);
            set.Add(3);
            Assert.True(set.Find(1));
            Assert.True(set.Find(2));
            Assert.True(set.Find(3));
            Assert.False(set.Find(4));
            Assert.Equal(3, set.Size());

            set.Remove(1);

            Assert.False(set.Find(1));
            Assert.True(set.Find(2));
            Assert.True(set.Find(3));
            Assert.False(set.Find(4));
            Assert.Equal(2, set.Size());

            set.Add(3);

            Assert.False(set.Find(1));
            Assert.True(set.Find(2));
            Assert.True(set.Find(3));
            Assert.False(set.Find(4));
            Assert.Equal(2, set.Size());
        }

        internal static void TestKVSet(IKVSet<int> set)
        {
            Assert.Equal(0, set.Size());

            for (int i = 0; i < 5000; i++)
                set.Add($"{i}", i);
            for (int i = 1000; i < 2000; i++)
                set.Remove($"{i}");
            for (int i = 1500; i < 1600; i++)
                set.Add($"{i}", i);
            for (int i = 6000; i < 7000; i++)
                set.Add($"{i}", i);

            for (int i = 0; i < 1000; i++)
                Assert.Equal(i, set.Find($"{i}"));
            for (int i = 1000; i < 1500; i++)
                Assert.False(set.Has($"{i}"));
            for (int i = 1500; i < 1600; i++)
                Assert.Equal(i, set.Find($"{i}"));
            for (int i = 1600; i < 2000; i++)
                Assert.False(set.Has($"{i}"));
            for (int i = 2000; i < 5000; i++)
                Assert.Equal(i, set.Find($"{i}"));
            for (int i = 5000; i < 6000; i++)
                Assert.False(set.Has($"{i}"));
            for (int i = 6000; i < 7000; i++)
                Assert.Equal(i, set.Find($"{i}"));

            Assert.Equal(5100, set.Size());
        }
    }
}
