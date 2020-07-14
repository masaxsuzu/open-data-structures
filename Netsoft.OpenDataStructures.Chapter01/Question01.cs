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
            while(!stdin.EndOfStream)
            {
                lines.Push(stdin.ReadLine());
            }
            while(lines.Count != 0)
            {
                stdout.WriteLine(lines.Pop());
            }
        }

        public static void Answer02(StreamReader stdin, StreamWriter stdout)
        {
            while (!stdin.EndOfStream)
            {
                foreach (string line in stdin.ReadLines(50).Reverse())
                {
                    stdout.WriteLine(line);
                }
            }
        }

        private static string[] ReadLines(this StreamReader stdin, int by)
        {
            var lines = new List<string>();
            while (lines.Count < by || !stdin.EndOfStream)
            {
                lines.Add(stdin.ReadLine());
            }
            return lines.ToArray();
        }
    }
}
