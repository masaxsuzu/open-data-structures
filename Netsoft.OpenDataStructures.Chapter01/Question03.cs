using System;
using System.Collections.Generic;
using System.Text;

namespace Netsoft.OpenDataStructures.Chapter01
{
    public static class Question03
    {
        public static bool Answer(string[] input)
        {
            var stack = new Stack<string>();
            int n = 0;
            while(n < input.Length)
            {
                if(!_try(stack, input, ref n))
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }
        private static bool _try(Stack<string> stack, string[] input, ref int n)
        {
            string v = input[n];
            n++;
            switch (v)
            {
                case "{":
                    stack.Push(v);
                    return isClosed("}", stack, input, ref n);
                case "(":
                    stack.Push(v);
                    return isClosed(")", stack, input, ref n);
                case "[":
                    stack.Push(v);
                    return isClosed("]", stack, input, ref n);
                default:
                    return false;
            }
        }
        private static bool isClosed(string closing, Stack<string> stack, string[] input, ref int n)
        {
            do
            {
                string v = input[n];
                if(v == closing)
                {
                    n++;
                    stack.Pop();
                    return true;
                }
                if(!_try(stack, input, ref n))
                {
                    return false;
                }
            } while (n < input.Length);
            return false;
        }
    }
}
