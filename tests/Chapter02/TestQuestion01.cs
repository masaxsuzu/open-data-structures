using Netsoft.OpenDataStructures.Chapter01;
using Netsoft.OpenDataStructures.Chapter02;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tests.Netsoft.OpenDataStructures.Chapter01;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter02
{
    public class TestQuestion01
    {
        [Fact]
        public void Test01()
        {
            Common.TestInterface.TestVector(new Vector<int>());
        }

        [Fact]
        public void Test02()
        {
            var vec = new Vector<int>();
            int[] input = Enumerable.Range(0, 10000).ToArray();
            foreach (int item in input)
            {
                vec.Add(item, item);
            }

            Assert.Equal(10000, vec.Size());
            Assert.Equal(0, vec.Get(0));
            Assert.Equal(9999, vec.Get(9999));
        }

        [Fact]
        public void Test03()
        {
            var vec = new Vector<int>();
            int[] input = Enumerable.Range(0, 10000).ToArray();

            vec.AddRange(0, input);

            Assert.Equal(10000, vec.Size());
            Assert.Equal(0, vec.Get(0));
            Assert.Equal(9999, vec.Get(9999));
        }
    }
}
