﻿using Netsoft.OpenDataStructures.Chapter01;
using Netsoft.OpenDataStructures.Chapter02;

using System;
using System.Collections.Generic;
using System.Text;

using Tests.Netsoft.OpenDataStructures.Chapter01;

using Xunit;

namespace Tests.Netsoft.OpenDataStructures.Chapter02
{
    public class TestDualArrayDequeue
    {
        [Fact]
        public void Test01()
        {
            Common.TestInterface.TestVector(new DualArrayDeque<int>());
        }

        [Fact]
        public void Test02()
        {
            Common.TestInterface.TestStack(new DualArrayDeque<int>());
        }

        [Fact]
        public void Test03()
        {
            Common.TestInterface.TestQueue(new DualArrayDeque<int>());
        }
    }
}
