using System;
using System.Diagnostics;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution sln = new Solution();
            Trace.Assert(sln.Reverse(1234)==4321);
            Trace.Assert(sln.Reverse(-1234)==-4321);
            Trace.Assert(sln.Reverse(120)==21);
            Trace.Assert(sln.Reverse(0)==0);
            Trace.Assert(sln.Reverse(1534236469)==0);
            Trace.Assert(sln.Reverse(-1534236469)==0);
        }
    }
}
