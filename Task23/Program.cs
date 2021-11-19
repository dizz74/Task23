using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task23
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите число:");
            int input = Convert.ToInt32(Console.ReadLine());

            int calced = FactorialAsync(input).Result;//block
            Console.WriteLine("Факториал числа {0}={1}", input, calced);

            FactorialAsyncBg(input);//not block, CS4014 warning
            Console.WriteLine("Идет фоновое вычисление, ждите результата");
            Console.ReadKey();
        }



        static async Task<int> FactorialAsync(int n)
        {
            int factorial = await Task.Run(() => Factorial(n));
            return factorial;
        }

        static async Task FactorialAsyncBg(int n)
        {
            int factorial = await Task.Run(() => Factorial(n));
            Console.WriteLine("(фон) Факториал числа {0}={1}", n, factorial);

        }


        static int Factorial(int n)
        {
            Thread.Sleep(50);
            if (n > 1) return n * Factorial(n - 1);
            else return 1;
        }
    }
}
