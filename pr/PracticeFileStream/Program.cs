using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            var dictonary = new Dictionary<char, int>();

            using(var stream = new FileStream("data.bin", FileMode.Open))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                var result = Encoding.UTF8.GetString(buffer);

                foreach(char symbol in result)
                {
                    if (dictonary.ContainsKey(symbol))
                        dictonary[symbol]++;
                    else
                        dictonary[symbol] = 0;
                }
                foreach(var dc in dictonary)
                    Console.WriteLine(dc.Key + " " + dc.Value);
            }
             // 2 
            string name = "Pedro";
            string surName = "Rodriguez";
            int age = 29;
            using (StreamWriter streamW = new StreamWriter("person.txt"))
            {
                streamW.WriteLine(name);
                streamW.WriteLine(surName);
                streamW.WriteLine(age);
            }
        }
    }
}
