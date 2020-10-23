using Netsoft.OpenDataStructures.Chapter05;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter05
{
    public class TestOpenAddressingHashMap
    {
        [Fact]
        public void Test01()
        {
            Common.TestInterface.TestKVSet(new OpenAddressingHashMap<int>());
        }
    }
}
