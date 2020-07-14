using Netsoft.OpenDataStructures.Chapter01;
using Netsoft.OpenDataStructures.Chapter02;

using System;
using System.Collections.Generic;
using System.Text;

using Tests.Netsoft.OpenDataStructures.Chapter01;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter02
{
    public class TestArrayQueue
    {
        [Fact]
        public void Test02()
        {
            var got = new List<int>();
            var stack = new ArrayQueue<int>();

            stack.Enqueue(1);
            stack.Enqueue(2);
            stack.Enqueue(3);

            got.Add(stack.Dequeue());
            got.Add(stack.Dequeue());
            got.Add(stack.Dequeue());

            Assert.Equal(new int[] { 1, 2, 3 }, got);
        }
    }
}
