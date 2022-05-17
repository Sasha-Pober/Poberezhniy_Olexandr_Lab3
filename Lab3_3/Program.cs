using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter edges of interval:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int[] arr = new int[0];
            int count = 0;
            for ( int i = a; i < b; i++)
            { 
                Array.Resize(ref arr, arr.Length + 1);
                arr[count] = i;
                count++;
            }

            var numbers = arr.Where(n => n % 2 != 0).Select(n => n.ToString()).OrderBy(n => n);

            Console.WriteLine("\nThe intital array: ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\nConverted and sorted array:");
            foreach (var digit in numbers)
            {
                Console.Write( digit + " ");
            }

            Console.ReadKey();
        }
    }
}
