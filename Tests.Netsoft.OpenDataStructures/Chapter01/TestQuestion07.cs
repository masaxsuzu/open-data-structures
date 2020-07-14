using System;
using System.IO;
using System.Linq;
using System.Text;

using Xunit;

using Netsoft.OpenDataStructures.Interfaces;
using Netsoft.OpenDataStructures.Chapter01;
using System.Collections.Generic;

namespace Tests.Netsoft.OpenDataStructures.Chapter01
{
    public class TestQuestion07
    {
        [Fact]
        public void TestAnswer01()
        {
            TestQuestion06._TestAnswer01(new CheatList());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        public void Benchmark_Answer02_Add_MyList(int n)
        {
            Benchmark_Answer02(new MyList(), n);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void Benchmark_Answer02_Add_CheatList(int n)
        {
            Benchmark_Answer02(new CheatList(), n);
        }

        private static void Benchmark_Answer02(IMyList<int> list, int n)
        {
            foreach (int item in Enumerable.Range(0,n))
            {

                list.Add(list.Size(), n);
            }
        }
    }
}