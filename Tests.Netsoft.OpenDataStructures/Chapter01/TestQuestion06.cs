using System;
using System.IO;
using System.Linq;
using System.Text;

using Xunit;

using Netsoft.OpenDataStructures.Chapter01;
using System.Collections.Generic;

namespace Tests.Netsoft.OpenDataStructures.Chapter01
{
    public class TestQuestion06
    {
        [Fact]
        public void TestAnswer01()
        {
            var list = new MyList();
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

            list.Add(1,5);
            list.Add(1,6);

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
    }
}