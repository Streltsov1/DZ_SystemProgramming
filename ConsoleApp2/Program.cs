using System;

namespace ConsoleApp2
{
    internal class Program
    {
        struct Range
        {
            public int start;
            public int end;
        }
        static void Main(string[] args)
        {
            //Range range = new Range()
            //{
            //    start = 1,
            //    end = 100,
            //};
            //Task task1 = new Task(Task1Time);
            //task1.Start();
            //Task.Factory.StartNew(() => task1.Start());
            //Task.Run(() => task1.Start());
            //Task<int> task2 = new Task<int>(() => Task2Numbers(range));
            //task2.Start();
            //task2.Wait();
            //Console.WriteLine($"Result: {task2.Result}");
            int[] array = new int[100];
            Random rnd = new Random();
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1000);
            }
            Task<double>[] task4 = new Task<double>[4]
                {
                    new Task<double>(() => Task4Min((object)array)),
                    new Task<double>(() => Task4Max((object)array)),
                    new Task<double>(() => Task4Avg((object)array)),
                    new Task<double>(() => Task4Sum((object)array))
                };
            foreach(var task in task4)
                task.Start();
            foreach (var item in task4)
            {
                Console.WriteLine($"Result:{item.Result}");
            }
            Console.ReadKey();
        }
        static void Task1Time()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{DateTime.Now}");
                Thread.Sleep(1000);
            }
        }
        static int Task2Numbers(object obj)
        {
            Range range = (Range)obj;
            if(range.start <= 0)
                range.start = 1;
            if (range.end <= 0)
                range.end = 1;
            if (range.start > range.end)
            {
                range.start += range.end;
                range.end = range.start - range.end;
                range.start -= range.end;
            }
            int count = 0;
            int k = 0;
            for (int i = range.start; i <= range.end; i++)
            {
                k = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        k++;
                    }
                }
                if (k == 2)
                {
                    count++;
                    Console.WriteLine(i);
                    Thread.Sleep(10);
                }
            }
            return count;
        }
        static double Task4Max(object obj)
        {
            int[] array = (int[])obj;
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if(max < array[i])
                    max= array[i];
            }
            return max;
        }
        static double Task4Min(object obj)
        {
            int[] array = (int[])obj;
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                    min = array[i];
            }
            return min;
        }
        static double Task4Avg(object obj)
        {
            int[] array = (int[])obj;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum/array.Length;
        }
        static double Task4Sum(object obj)
        {
            int[] array = (int[])obj;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}