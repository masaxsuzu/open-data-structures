using Netsoft.OpenDataStructures.Chapter04;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter04
{
    public class TestSkiplistSSet
    {
        [Fact]
        public void Test01()
        {
            Common.TestInterface.TestSSet(new SkiplistSSet<int>());
        }
    }
}