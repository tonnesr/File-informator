using System;
using System.Diagnostics;
using System.IO;

namespace FileInformator
{
    class Program
    {
        static FileInfo loadedFile;
        static char prefixCommand = '-';
        static string[] commands = new string[] {"f", "h", "help", "list", "a"};

        private static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == prefixCommand + commands[0])
                {
                    if (args[i + 1] != null)
                    {
                        string FileURL = args[i + 1];
                        i++; // skip?
                        loadedFile = LoadFile(FileURL);
                    }
                    else
                    {
                        Console.Write("Specify an URL. ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Example: -f C:\\files\\file.png");
                        Console.ResetColor();
                        break;
                    }
                }
                else if (args[i] == prefixCommand + commands[1] || args[i] == prefixCommand + commands[2] || args[i] == prefixCommand + commands[3])
                {
                    Console.WriteLine("Commands available:");
                    foreach (string item in commands)
                    {
                        Console.WriteLine("  " + item);
                    }
                }
                else if (args[i] == prefixCommand + commands[4])
                {
                    if (loadedFile != null)
                    {
                        GetFileInformation(loadedFile);
                    }
                    else
                    {
                        Console.WriteLine("Use the command -f to load a file, before using -a.");
                        break;
                    }
                }
                else
                {
                    Console.Write(args[i] + " command not recognised. Try -h, -help or -list for help/commands.");
                    break;
                }
            }
            
            Console.ReadKey();
        }

        private static FileInfo LoadFile(string url)
        {
            FileInfo file;

            if (File.Exists(url))
            {               
                file = new FileInfo(url);
            }
            else
            {
                file = null;
                Console.WriteLine(url + " is not a valid path for a file.");
            }

            return file;
        }

        private static void GetFileInformation(FileInfo info)
        {
            FileAttributes attributes = info.Attributes;
           
            Console.WriteLine("File info:\n  Name: " + info.Name + "\n  Extension: " + info.Extension + "\n  Lenght: " + info.Length + " bytes");

            Console.WriteLine("Attributes: ");
            // Read only file
            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                Console.WriteLine("  File is readonly");
            }
            else
            {
                Console.WriteLine("  File is not readonly.");
            }
            // Hidden file
            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                Console.WriteLine("  File is hidden.");
            }
            else
            {
                Console.WriteLine("  File is not hidden.");
            }
            // Archive
            if ((attributes & FileAttributes.Archive) == FileAttributes.Archive)
            {
                Console.WriteLine("  File is an archive.");
            }
            else
            {
                Console.WriteLine("  File is not an archive.");
            }
            // System file
            if ((attributes & FileAttributes.System) == FileAttributes.System)
            {
                Console.WriteLine("  File is a system file.");
            }
            else
            {
                Console.WriteLine("  File is not a system file.");
            }
            // Temporary file
            if ((attributes & FileAttributes.Temporary) == FileAttributes.Temporary)
            {
                Console.WriteLine("  File is an temporary file.");
            }
            else
            {
                Console.WriteLine("  File is not an temporary file.");
            }
        }
    }
}
