using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleApp4
{
    class Program
    {
        struct Range
        {
            public int start;
            public int end;
            public int threadnum;
            public int number;
        }
        static void ThreadFunk(object range)
        {
            Range range1 = (Range)range;
            if (range1.start > range1.end)
            {
                range1.start += range1.end;
                range1.end = range1.start - range1.end;
                range1.start -= range1.end;
            }
            for (int i = range1.start; i < range1.end; i++)
            {
                Console.WriteLine($"thread {range1.number} - {i}");
                Thread.Sleep(100);
            }
        }
        static void Main(string[] args)
        {
            Range range = new Range();
            range.start = 0;
            range.end = 100;
            range.threadnum = 5;
            range.number = 1;
            Range range1 = new Range();
            range1.start = 0;
            range1.end = 0;
            range1.threadnum = 0;
            range1.number = 1;
            Thread[] threads = new Thread[range.threadnum];
            for (int i = 0; i < range.threadnum; i++)
            {
                if (i == 0)
                    range1.start = range.start;
                else
                    range1.start += (range.end - range.start)/range.threadnum;
                range1.end += (range.end - range.start) / range.threadnum;
                range1.number = i + 1;
                threads[i] = new Thread(ThreadFunk);
                threads[i].Start((object)range1);
            }
        }
    }
}