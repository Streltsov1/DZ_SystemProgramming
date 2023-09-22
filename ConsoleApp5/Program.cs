using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завдання 1-2
            Parallel.Invoke(() => Factorial(5),() => NumberOfDigit(32670),() => SumOfDigit(1234));
            //завдання 3
            Parallel.For(6, 8, MultiplicationTable);
            //завдання 4
            StreamReader file = new StreamReader("Number.txt");
            List<int> num = new List<int>();
            while (!file.EndOfStream)
            {
                num.Add(int.Parse(file.ReadLine()));
            }
            file.Close();
            Parallel.ForEach(num, Factorial);
            //завдання 5
            var sum = num.AsParallel().Sum();
            var Max = num.AsParallel().Max();
            var Min = num.AsParallel().Min();
            Console.WriteLine($"Sum: {sum}\nMax: {Max}\nMin: {Min}");
            Console.ReadKey();
        }
        static void Factorial(int num)
        {
            double result = 1;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }
            //Thread.Sleep(1000);
            Console.WriteLine($"Result: {result}");
        }
        static void NumberOfDigit(int num)
        {
            int digit = 0;
            while(num > 0) 
            {
                digit++;
                num /= 10;
            }
            //Thread.Sleep(1000);
            Console.WriteLine($"Digit: {digit}");
        }
        static void SumOfDigit(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num%10;
                num /= 10;
            }
            //Thread.Sleep(1000);
            Console.WriteLine($"Sum: {sum}");
        }
        static void MultiplicationTable(int num) 
        {
            string path = $"Table_{num}.txt";
            StreamWriter output = new StreamWriter(path);
            for (int i = 1; i <= 10; i++)
            {
                output.WriteLine($"{num} * {i} = {num * i}");
            }
            output.Close();
            Console.WriteLine($"{path} created");
        }
    }
}