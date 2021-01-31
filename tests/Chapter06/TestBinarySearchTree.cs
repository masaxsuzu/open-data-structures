using Netsoft.OpenDataStructures.Chapter06;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter06
{
    public class TestBinarySearchTree
    {
        [Fact]
        public void Test01()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(7);
            tree.Add(3);
            tree.Add(11);

            tree.Add(1);
            tree.Add(5);
            tree.Add(4);
            tree.Add(6);

            tree.Add(9);
            tree.Add(13);
            tree.Add(8);
            tree.Add(12);
            tree.Add(14);

            Assert.Equal(12, tree.Size());

            tree.Remove(9);
            tree.Remove(13);
            tree.Remove(8);
            tree.Remove(12);
            tree.Remove(14);
            
            Assert.Equal(7, tree.Size());
        }

        [Fact]
        public void Test02()
        {
            Common.TestInterface.TestSSet(new BinarySearchTree<int>());
        }
    }
}
