using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4_1
{
    class Program
    {
        public class Node<T>
        {
            public Node<T> Next { get; set; }
            public T Data { get; set; }
            public Node(T t)
            {
                Next = null;
                Data = t;
            }
        }
        
        public class GenericList<T>
        {
            private Node<T> head;
            private Node<T> tail;
            public GenericList()
            {
                tail = head = null;
            }
            public Node<T> Head
            {
                get => head;
            }
            public void AddToTail(T t)
            {
                Node<T> n = new Node<T>(t);
                if (tail == null)
                {
                    head = tail = n;
                }
                else
                {
                    tail.Next = n;
                    tail = n;
                }
            }
            public void ForEach(Action<T> action){
                Node<T> node = head;
                while (node != null)
                {
                    action(node.Data);
                    node = node.Next;
                }
            }
        }
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                list.AddToTail(x);
            }

            list.ForEach(x => Console.WriteLine(x));

            int max = list.Head.Data;
            list.ForEach(x => max = x > max ? x : max);
            Console.WriteLine($"max:{max}");

            int min = list.Head.Data;
            list.ForEach(x => min = x < min ? x : min);
            Console.WriteLine($"min:{min}");

            int sum = 0;
            list.ForEach(x => sum += x);
            Console.WriteLine($"sum:{sum}");

            Console.ReadKey();
        }
    }
}
