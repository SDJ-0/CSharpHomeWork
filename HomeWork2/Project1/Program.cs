using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2_1
{
    class Program
    {
        static bool Check(string str)
        {
            if (str == "")
                return false;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9')
                    return false;
            }
            return true;
        }

        static void Prime_Factor(int num,out int[] factor)
        {
            int count = 0;
            int[] temp = new int[num];
            for(int i = 2; i <= num; i++)
            {
                if (num % i != 0)
                    continue;
                while (num % i == 0)
                    num /= i;
                temp[count] = i;
                count++;
            }
            if (count == 0)
                factor = null;
            else
                factor = new int[count];
            for (int i = 0; i < count; i++)
                factor[i] = temp[i];
        }

        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            if (!Check(str))
            {
                Console.WriteLine("Input error!");
                Console.ReadKey();
                return;
            }
            Prime_Factor(Int32.Parse(str), out int[] factor);
            if (factor == null)
            {
                Console.WriteLine("No prime factors!");
                Console.ReadKey();
                return;
            }
            for (int i = 0; i < factor.Length; i++)
                Console.WriteLine(factor[i]);
            Console.ReadKey();
        }
    }
}
