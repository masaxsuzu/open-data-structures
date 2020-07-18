using Netsoft.OpenDataStructures.Chapter01;
using Netsoft.OpenDataStructures.Chapter02;
using Netsoft.OpenDataStructures.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tests.Netsoft.OpenDataStructures.Chapter01;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter02
{
    public class TestQuestion02
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(10000)]
        public void Test01(int n)
        {

            int[] expected = Enumerable.Range(0, n).ToArray();
            _Test(expected, new RandomQueue<int>(1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        public void Test02(int n)
        {

            int[] expected = Enumerable.Range(0, n).ToArray();
            _Test(expected, new ArrayQueue<int>());
        }

        private void _Test(int[] expected, IQueue<int> queue)
        {
            var got = new List<int>();

            foreach (int item in expected)
            {
                queue.Enqueue(item);
            }

            foreach (int _ in expected)
            {
                got.Add(queue.Dequeue());
            }

            Assert.Equal(expected, got.OrderBy(x => x));
        }
    }
}
