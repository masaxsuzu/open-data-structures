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
            _TestAnswer01(new MyList());
        }
        private void _TestAnswer01(IMyList<int> list)
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
        [Fact]
        public void TestAnswer02()
        {
            _TestAnswer02(new MySSet());
        }
        private void _TestAnswer02(IMySSet<int> list)
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
            _TestAnswer03(new MyUSet());
        }
        private void _TestAnswer03(IMyUSet<int> list)
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