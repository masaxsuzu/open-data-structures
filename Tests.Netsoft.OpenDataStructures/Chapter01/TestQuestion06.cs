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
    public class TestQuestion06
    {
        [Fact]

        public void TestAnswer01()
        {
            Common.TestInterface.TestVector(new MyList<int>());
        }

        [Fact]
        public void TestAnswer02()
        {
            _TestAnswer02(new MySSet<int>());
        }
        private static void _TestAnswer02(IUSet<int> list)
        {
            Assert.Equal(0, list.Size());

            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.True(list.Find(1));
            Assert.True(list.Find(2));
            Assert.True(list.Find(3));
            Assert.Equal(3, list.Size());

            list.Remove(1);

            Assert.False(list.Find(1));
            Assert.True(list.Find(2));
            Assert.True(list.Find(3));
            Assert.Equal(2, list.Size());

            list.Add(3);

            Assert.False(list.Find(1));
            Assert.True(list.Find(2));
            Assert.True(list.Find(3));
            Assert.Equal(2, list.Size());
        }

        [Fact]
        public void TestAnswer03()
        {
            _TestAnswer03(new MyUSet<int>());
        }
        private static void _TestAnswer03(ISSet<int> list)
        {
            Assert.Equal(0, list.Size());

            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.True(list.Find(1));
            Assert.True(list.Find(2));
            Assert.True(list.Find(3));
            Assert.False(list.Find(4));
            Assert.Equal(3, list.Size());

            list.Remove(1);

            Assert.True(list.Find(1));
            Assert.True(list.Find(2));
            Assert.True(list.Find(3));
            Assert.False(list.Find(4));
            Assert.Equal(2, list.Size());

            list.Add(3);

            Assert.True(list.Find(1));
            Assert.True(list.Find(2));
            Assert.True(list.Find(3));
            Assert.False(list.Find(4));
            Assert.Equal(2, list.Size());
        }
    }
}