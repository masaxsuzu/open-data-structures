using Netsoft.OpenDataStructures.Chapter06;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter06
{
    public class TestBinaryTree
    {
        [Fact]
        public void Test01()
        {
            var nodes = Enumerable.Range(0, 15).Select(i => new Node<int>(Math.Max(1, i))).ToArray();

            // 1, 1, 2, ... 10, ... 14
            // 0, 1, 2, ... 10, ... 14
            // x, o, o, ...  o, ...  o

            var root = nodes[7];
            SetChildren(root, nodes[3], nodes[11]);
            
            SetChildren(nodes[3], nodes[1], nodes[5]);
            SetChildren(nodes[11], nodes[9], nodes[13]);

            SetChildren(nodes[5], nodes[4], nodes[6]);
            SetChildren(nodes[9], nodes[8], null);
            SetChildren(nodes[13], nodes[12], nodes[14]);

            var tree = new BinaryTree<int>();
            Assert.Equal(12, tree.Size(root));
            Assert.Equal(3, tree.Size(nodes[5]));

            Assert.Equal(4, tree.Height(root));
            Assert.Equal(3, tree.Height(nodes[11]));

            Assert.Equal(3, tree.Depth(nodes[5]));
            Assert.Equal(4, tree.Depth(nodes[8]));

            tree.Root = root;
            Assert.Equal(12, tree.Traverse().ToArray().Length);

        }
        private void SetChildren<T>(Node<T> u, Node<T> left, Node<T> right)
        {
            u.Left = left;
            u.Right = right;
            if (left != null){
                left.Parent = u;
            }
            if (right != null) {
                right.Parent = u;
            }
        }
    }
}
