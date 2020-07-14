using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Netsoft.OpenDataStructures.Chapter01
{
    public static class Question01
    {
        public static void Answer01(StreamReader stdin, StreamWriter stdout)
        {
            var lines = new Stack<string>();
            while (!stdin.EndOfStream)
            {
                lines.Push(stdin.ReadLine());
            }
            while (lines.Count != 0)
            {
                stdout.WriteLine(lines.Pop());
            }
        }

        public static void Answer02(StreamReader stdin, StreamWriter stdout)
        {
            while (!stdin.EndOfStream)
            {
                foreach (string line in stdin.ReadLines(50).ToArray().Reverse())
                {
                    stdout.WriteLine(line);
                }
            }
        }

        private static List<string> ReadLines(this StreamReader stdin, int by)
        {
            var lines = new List<string>();
            while (lines.Count < by && !stdin.EndOfStream)
            {
                lines.Add(stdin.ReadLine());
            }
            return lines;
        }

        public static void Answer03(StreamReader stdin, StreamWriter stdout)
        {
            var lines = stdin.ReadLines(41);

            if (stdin.EndOfStream)
            {
                return;
            }

            do
            {
                string line = stdin.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    stdout.WriteLine(lines[0]);
                }

                lines.RemoveAt(0);
                lines.Add(line);

            } while (!stdin.EndOfStream);
        }

        public static void Answer04(StreamReader stdin, StreamWriter stdout)
        {
            var uniqueLines = new HashSet<string>();
            while (!stdin.EndOfStream)
            {
                string line = stdin.ReadLine();
                if (!uniqueLines.Contains(line))
                {
                    uniqueLines.Add(line);
                    stdout.WriteLine(line);
                }
            }
        }
    }
}
