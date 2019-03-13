using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string result;
            using (FileStream fileStream = File.OpenRead("Fibonacci.txt"))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);

                result = Encoding.UTF8.GetString(buffer);
            }

            List<int> array = new List<int>();

            foreach (char c in result)
            {
                if (c >= '0' && c <= '9')
                {
                    array.Add((int)Char.GetNumericValue(c));
                }
            }
            int sizeArray = 15;
            while (array.Count < sizeArray)
            {
                array.Add((array.Last()) + array.ElementAt((array.IndexOf(array.Last()))-1));          
            }
            string fibonacci = string.Join(" ", array);

            using (FileStream fileStream = new FileStream("FibonacciNew.txt", FileMode.Create))
            {
                byte[] bytesNumFibo = Encoding.UTF8.GetBytes(fibonacci);
                fileStream.Write(bytesNumFibo, 0, bytesNumFibo.Length);
            }
            Console.WriteLine(fibonacci);
        }
    }
}
