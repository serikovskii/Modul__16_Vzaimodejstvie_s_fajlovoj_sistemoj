using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;

            Console.WriteLine("Выберите порядковый номер диска " +
               "в котором вы хотите хранить файл");

            DriveInfo[] drives = DriveInfo.GetDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                if(drives[i].IsReady && drives[i].DriveType == DriveType.Fixed)
                Console.WriteLine($"{i}.{drives[i].Name}");
            }
            int position = int.Parse(Console.ReadLine());
            path += drives[position].Name;

            foreach (var directory in drives[position].RootDirectory.EnumerateDirectories())
            {
                Console.WriteLine(directory.Name);
            }

            Console.WriteLine("Напишите название новой диретории, куда хотите сохрнить файл");

            path +=  Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Console.WriteLine("Напишите название файла");

            path += @"\" + Console.ReadLine();

            if (!File.Exists(path))
            {
                using (File.Create(path)) ;

            }

            string data = "Раз два три";

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] bytesData = Encoding.UTF8.GetBytes(data);
                fileStream.Write(bytesData, 0, bytesData.Length);
            }

            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);

                string result = Encoding.UTF8.GetString(buffer);

            }

            using (var stream = new StreamReader(path))
            {
                string text = stream.ReadToEnd();
            }

        }
    }
}
