using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2_2
{
    class Program
    {
        static bool Check(string str)
        {
            if (str == "")
                return false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9')
                    return false;
            }
            return true;
        }

        static void Get_Max_Min(int[] array,out int max,out int min)
        {
            max = array[0];
            min = array[0];
            for(int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                max = max > temp ? max : temp;
                min = min < temp ? min : temp;
            }
        }

        static void Get_Average_Sum(int[] array, out double average, out int sum)
        {
            sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            average = (double)sum / array.Length;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The length of array:");
            string str = Console.ReadLine();
            if (!Check(str))
            {
                Console.WriteLine("Error input!");
                Console.ReadKey();
                return;
            }
            int num = Int32.Parse(str);
            int[] array = new int[num];
            for(int i = 0; i < num; i++)
            {
                Console.WriteLine($"The value of number {i} element:");
                string ele = Console.ReadLine();
                if (!Check(ele))
                {
                    Console.WriteLine("Error input!");
                    Console.ReadKey();
                    return;
                }
                array[i] = Int32.Parse(ele);
            }
            Get_Max_Min(array, out int max, out int min);
            Get_Average_Sum(array, out double average, out int sum);
            Console.WriteLine($"Max:{max}");
            Console.WriteLine($"Min:{min}");
            Console.WriteLine($"Average:{average}");
            Console.WriteLine($"Sum:{sum}");
            Console.ReadKey();
        }
    }
}
