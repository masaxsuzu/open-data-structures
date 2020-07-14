using System;
using System.IO;
using System.Linq;
using System.Text;

using Xunit;

using Netsoft.OpenDataStructures.Chapter01;
using System.Collections.Generic;

namespace Tests.Netsoft.OpenDataStructures.Chapter01
{
    public class TestQuestion04
    {
        [Fact]
        public void TestAnswer()
        {
            var stack = new Stack<int>(new int[] { 1, 2, 3 });
            var actual = Question04.Answer(stack);
            Assert.Equal(new int[] {1, 2, 3}, actual.ToArray());
        }
    }
}
