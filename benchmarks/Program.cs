using BenchmarkDotNet.Running;

using System;
using System.Numerics;

namespace Benchmarks.Netsoft.OpenDataStructures
{
    class Program
    {
        static void Main()
        {
            var summary = BenchmarkRunner.Run<Vectors>();
        }
    }
}
