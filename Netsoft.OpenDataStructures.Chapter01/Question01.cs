using System;
using System.Collections.Generic;
using System.IO;

namespace Netsoft.OpenDataStructures.Chapter01
{
    public class Question01
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
    }
}
