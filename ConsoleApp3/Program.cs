using System.Drawing;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                Console.WriteLine("Enter size of array A: ");
                int M = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter size of array B: ");
                int N = int.Parse(Console.ReadLine());
                int* A = stackalloc int[M];
                int* B = stackalloc int[N];
                int* C = stackalloc int[M+N];
                Random rnd = new Random();
                for (int i = 0; i < M; i++)
                {
                    A[i] = rnd.Next(1000);
                }
                for (int i = 0; i < N; i++)
                {
                    B[i] = rnd.Next(1000);
                }
                for (int i = 0; i < M; i++)
                {
                    C[i] = A[i];
                }
                for (int i = 0; i < N; i++)
                {
                    C[M + i] = B[i];
                }
                Console.Write("A: ");
                for (int i = 0; i < M; i++)
                {
                    Console.Write(A[i] + " ");
                }
                Console.Write("\nB: ");
                for (int i = 0; i < N; i++)
                {
                    Console.Write(B[i] + " ");
                }
                Console.Write("\nC: ");
                for (int i = 0; i < M+N; i++)
                {
                    Console.Write(C[i] + " ");
                }
            }
        }
    }
}