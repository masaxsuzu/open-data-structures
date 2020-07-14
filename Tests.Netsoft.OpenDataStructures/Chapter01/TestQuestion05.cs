using System;
using System.IO;
using System.Linq;
using System.Text;

using Xunit;

using Netsoft.OpenDataStructures.Chapter01;
using System.Collections.Generic;

namespace Tests.Netsoft.OpenDataStructures.Chapter01
{
    public class TestQuestion05
    {
        [Fact]
        public void TestInit()
        {
            var bag = new Bag();

            Assert.False(bag.Find(1));
            Assert.False(bag.Remove(1));
        }

        [Fact]
        public void TestAdd()
        {
            var bag = new Bag();

            bag.Add(1);
            bool got = bag.Find(1);
            Assert.True(got);
        }

        [Fact]
        public void TestAddMultiple()
        {
            var bag = new Bag();

            bag.Add(1);
            bag.Add(1);
            Assert.True(bag.Find(1));
            Assert.Equal(2, bag.FindAll(1));
        }

        [Fact]
        public void TestRemove()
        {
            var bag = new Bag();

            bag.Add(1);
            bag.Remove(1);

            Assert.False(bag.Find(1));
            Assert.Equal(0, bag.FindAll(1));
        }

        [Fact]
        public void TestRemoveMultiple()
        {
            var bag = new Bag();

            bag.Add(1);
            bag.Add(1);
            bag.Add(2);
            bag.Remove(1);

            Assert.Equal(1, bag.FindAll(1));
            Assert.Equal(1, bag.FindAll(2));
        }
    }
}
