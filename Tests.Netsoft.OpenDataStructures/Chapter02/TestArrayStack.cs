using Netsoft.OpenDataStructures.Chapter01;
using Netsoft.OpenDataStructures.Chapter02;

using System;
using System.Collections.Generic;
using System.Text;

using Tests.Netsoft.OpenDataStructures.Chapter01;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter02
{
    public class TestArrayStack
    {
        [Fact]
        public void Test01()
        {
            Common.TestInterface.TestVector(new ArrayStack<int>());
        }

        [Fact]
        public void Test02()
        {
            var got = new List<int>();
            var stack = new ArrayStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            got.Add(stack.Pop());
            got.Add(stack.Pop());
            got.Add(stack.Pop());

            Assert.Equal(new int[] { 3, 2, 1 }, got);
        }
    }
}
