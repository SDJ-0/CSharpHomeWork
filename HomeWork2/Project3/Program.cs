using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the number:");
            int n;
            try
            {
                n = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error Inpput!");
                Console.ReadKey();
                return;
            }
            bool[] Is_Prime = new bool[n + 1];
            for (int i = 0; i < n + 1; i++)
                Is_Prime[i] = true;
            for (int i = 2; i * i <= n; i++) 
                for (int j = 2; i * j <= n; j++)
                {
                    Is_Prime[i * j] = false;
                }
            for (int i = 2; i <= n; i++)
                if (Is_Prime[i])
                {
                    Console.WriteLine(i);
                }
            Console.ReadKey();
        }
    }
}
