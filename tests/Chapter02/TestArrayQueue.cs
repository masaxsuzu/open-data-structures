using Netsoft.OpenDataStructures.Chapter01;
using Netsoft.OpenDataStructures.Chapter02;

using System;
using System.Collections.Generic;
using System.Text;

using Tests.Netsoft.OpenDataStructures.Chapter01;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter02
{
    public class TestArrayQueue
    {
        [Fact]
        public void Test02()
        {
            Common.TestInterface.TestQueue(new ArrayQueue<int>());
        }
    }
}
