using System;
using System.IO;

namespace CSharpTree
{
    class Program
    {
        private const int DepthIndent = 4;

        static void Main(string[] args)
        {
            string rootPath;
            if (args.Length > 0)
            {
                rootPath = args[0];
            }
            else
            {
                rootPath = Directory.GetCurrentDirectory();
            }

            Console.WriteLine($"Root path: {rootPath}");
            Walk(rootPath, 0);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void Walk(string path, int depth)
        {
            var childDirectories = Directory.GetDirectories(path);
            for (int i = 0; i < childDirectories.Length; i++)
            {
                var childPath = childDirectories[i];
                var prefix = string.Empty;
                if (depth > 0)
                {
                    prefix = "│" + new string(' ', DepthIndent - 1);
                }
                if (depth > 1)
                {
                    prefix += new string(' ', DepthIndent * (depth - 1));
                }
                if (i < childDirectories.Length - 1)
                {
                    Console.WriteLine($"{prefix}├───{Path.GetFileName(childPath)}");
                }
                else
                {
                    Console.WriteLine($"{prefix}└───{Path.GetFileName(childPath)}");
                }
                Walk(childPath, depth + 1);
            }
        }
    }
}
