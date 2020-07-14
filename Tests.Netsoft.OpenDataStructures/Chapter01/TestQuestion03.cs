using System;
using System.IO;
using System.Linq;
using System.Text;

using Xunit;

using Netsoft.OpenDataStructures.Chapter01;

namespace Tests.Netsoft.OpenDataStructures.Chapter01
{
    public class TestQuestion03
    {
        [Theory]
        [InlineData("(,)", true)]
        [InlineData("{,}", true)]
        [InlineData("[,]", true)]
        [InlineData("[,(,),]", true)]
        [InlineData("[,{,},]", true)]
        [InlineData("[,[,],]", true)]
        [InlineData("[,[,],)", false)]
        [InlineData("[,[,),]", false)]
        [InlineData("[,(,],]", false)]
        [InlineData("{,{,(,),[,],},}", true)]
        [InlineData("{,{,(,),],}", false)]
        public void TestAnswer(string @input, bool expected)
        {
            bool actual = Question03.Answer(@input.Split(','));
            Assert.Equal(expected, actual);
        }
    }
}
