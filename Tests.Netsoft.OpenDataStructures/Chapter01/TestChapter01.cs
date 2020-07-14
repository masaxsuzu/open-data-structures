using System;
using System.IO;
using System.Linq;
using System.Text;

using Xunit;

using Netsoft.OpenDataStructures.Chapter01;

namespace Tests.Netsoft.OpenDataStructures.Chapter01
{
    public class TestQuestion01
    {
        [Fact]
        public void TestAnswer03()
        {
            string input = @"first
2
3
fourth
5
6

8
9
10
1
2
3
4
5
6
7
8
9
10
1
2
3
4
5
6
7
8
9
10
1
2
3
4
5
6
7
8
9
10
1

3
4

";
            string expected = "first\r\nfourth\r\n";

            using var min = new MemoryStream(Encoding.UTF8.GetBytes(input));
            using var stdin = new StreamReader(min);
            using var mout = new MemoryStream();

            var stdout = new StreamWriter(mout);
            Question01.Answer03(stdin, stdout);

            stdout.Flush();
            min.Flush();

            string actual = Encoding.UTF8.GetString(mout.ToArray());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAnswer06()
        {
            string input = @"1
2
3
1
33
22
";
            string expected = "1\r\n2\r\n3\r\n22\r\n33\r\n";

            using var min = new MemoryStream(Encoding.UTF8.GetBytes(input));
            using var stdin = new StreamReader(min);
            using var mout = new MemoryStream();

            var stdout = new StreamWriter(mout);
            Question01.Answer06(stdin, stdout);

            stdout.Flush();
            min.Flush();

            string actual = Encoding.UTF8.GetString(mout.ToArray());

            Assert.Equal(expected, actual);
        }
    }
}
