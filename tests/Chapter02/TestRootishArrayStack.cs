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
    public class TestRootishArrayStack
    {
        [Fact]
        public void Test01()
        {
            Common.TestInterface.TestVector(new RootishArrayStack<int>());
        }

        [Fact]
        public void Test02()
        {
            Common.TestInterface.TestStack(new RootishArrayStack<int>());
        }
    }
}
