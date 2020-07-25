using Netsoft.OpenDataStructures.Chapter03;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter03
{
    public class TestSLList
    {
        [Fact]
        public void Test01()
        {
            Common.TestInterface.TestStack(new SLList<int>());
        }

        [Fact]
        public void Test02()
        {
            Common.TestInterface.TestStack(new SLList<int>());
        }
    }
}
