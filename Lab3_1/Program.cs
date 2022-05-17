using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Insert the full path to directory:");
            string path = Console.ReadLine();
            if (Directory.Exists(path))
            {
                //C:\Users\HP\Documents\test
                var folderList = new List<string>(Directory.EnumerateDirectories(path));
                int counter = folderList.Count;

                for(int i = 0; i < folderList.Count; i++)
                {
                    try
                    {
                        folderList.AddRange(Directory.EnumerateDirectories(folderList[i]));
                        folderList.AddRange(Directory.EnumerateFiles(folderList[i]));
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    catch (IOException)
                    {
                        continue;
                    }
                }

                folderList.InsertRange(counter, Directory.EnumerateFiles(path));

                foreach (var a in folderList)
                {
                    Console.WriteLine(a);
                }
            }
            else
                Console.WriteLine("The path isn't correct");
            Console.ReadKey();
        }
    }
}
