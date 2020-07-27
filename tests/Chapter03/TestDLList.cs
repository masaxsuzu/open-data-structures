using Netsoft.OpenDataStructures.Chapter03;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter03
{
    public class TestDLList
    {
        [Fact]
        public void Test01()
        {
            Common.TestInterface.TestVector(new DoubleLinkedList<int>());
        }
    }
}
