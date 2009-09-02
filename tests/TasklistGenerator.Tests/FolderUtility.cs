using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TasklistGenerator.Tests
{
    internal static class FolderUtility
    {
        public static string[] Files =
            new[]
                {
                    "one.cs",
                    "two.cs",
                    "three.cs"
                };
        public static DirectoryInfo InitilizeDirectories()
        {
            var dir = new DirectoryInfo("temp");
            dir.Create();
            using (var wr = File.CreateText(Path.Combine(dir.FullName, Files[0])))
            {
                wr.WriteLine("//TODO one two");
                wr.WriteLine("//TODO two");
                wr.WriteLine("Nothing");
            }
            using (File.Create(Path.Combine(dir.FullName, Files[1])))
            { }
            var sub = dir.CreateSubdirectory("test");
            using (File.Create(Path.Combine(sub.FullName, Files[2])))
            { }

            return dir;
        }
    }
}
