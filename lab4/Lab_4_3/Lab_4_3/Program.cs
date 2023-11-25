using System;
using System.IO;

namespace Task3
{
    public delegate void FileEvent(FileInfo fi);

    internal class FileWalker
    {
        public event FileEvent FoundEvent;

        public void WalkFiles(DirectoryInfo dir)
        {
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo f in files)
            {
                FoundEvent(f);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                WalkFiles(d);
            }
        }
    }

    public class Program
    {
        public static int fileNameLength;

        public static void Main()
        {
            Console.WriteLine("Enter name of directory:");
            string dirName = Console.ReadLine();

            Console.WriteLine("Enter length of file name:");
            fileNameLength = int.Parse(Console.ReadLine());

            DirectoryInfo dir = new DirectoryInfo(dirName);
            FileWalker walker = new FileWalker();
            walker.FoundEvent += FileFound;
            walker.WalkFiles(dir);
        }

        static void FileFound(FileInfo fi)
        {
            if (fi.Name.Length > fileNameLength)
            {
                Console.WriteLine(fi.Name);
            }
        }
    }
}