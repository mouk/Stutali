using System.Collections.Generic;
using System.IO;

namespace TasklistGenerator.Tests
{
    internal static class PathIterator
    {
        public static IEnumerable<string> Iterate(DirectoryInfo dir)
        {

            foreach (var s in dir.GetFiles("*.cs"))
            {
                yield return s.FullName;
            }

            foreach (var s in dir.GetDirectories())
            {
                foreach (var fileInfo in Iterate(s))
                {
                    yield return fileInfo;
                }
            }

        }
    }
}