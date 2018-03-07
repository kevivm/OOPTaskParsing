using System;
using System.Linq;

namespace OOPTaskParsing
{
    class PrintResults
    {
        public static void PrintParsedFiles(Files[] files)
        {
            Console.Write("Text files");
            Console.WriteLine();

            foreach (Files file in files)
            {
                try
                {
                    if (file.GetType() == typeof(TextFile))
                    {
                        var fileInfo = file.GetFileInfo();

                        Console.Write("\t" + fileInfo["Filename"]);
                        Console.WriteLine();
                        Console.WriteLine("\t\tExtension: " + fileInfo["Extension"]);
                        Console.WriteLine("\t\tSize: " + fileInfo["Size"]);
                        Console.WriteLine("\t\tContent: " + fileInfo["Content"]);
                    }
                }
                catch (NullReferenceException ex)
                {
                    
                }
            }

            Console.Write("Images");
            Console.WriteLine();
            foreach (Files file in files)
            {
                try
                {
                    if (file.GetType() == typeof(ImageFile))
                    {
                        var fileInfo = file.GetFileInfo();

                        Console.Write("\t" + fileInfo["Filename"]);
                        Console.WriteLine();
                        Console.WriteLine("\t\tExtension: " + fileInfo["Extension"]);
                        Console.WriteLine("\t\tSize: " + fileInfo["Size"]);
                        Console.WriteLine("\t\tResolution: " + fileInfo["Resolution"]);
                    }
                }
                catch (NullReferenceException ex)
                {

                }
            }

            Console.Write("Movies");
            Console.WriteLine();
            foreach (Files file in files)
            {
                try
                {
                    if (file.GetType() == typeof(MovieFile))
                    {
                        var fileInfo = file.GetFileInfo();

                        Console.Write("\t" + fileInfo["Filename"]);
                        Console.WriteLine();
                        Console.WriteLine("\t\tExtension: " + fileInfo["Extension"]);
                        Console.WriteLine("\t\tSize: " + fileInfo["Size"]);
                        Console.WriteLine("\t\tResolution: " + fileInfo["Resolution"]);
                        Console.WriteLine("\t\tDuration: " + fileInfo["Duration"]);
                    }
                }
                catch (NullReferenceException ex)
                {

                }
            }
        }
    }
}
