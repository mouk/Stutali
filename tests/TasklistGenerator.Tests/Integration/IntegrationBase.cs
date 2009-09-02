using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TasklistGenerator.Tests.Integration
{
    public class IntegrationBase : IDisposable
    {
        protected  Factory _theFactory;
        protected  DirectoryInfo _dir;
        protected string[] _files;

        public IntegrationBase()
        {
            _theFactory = new Factory();
            _dir = FolderUtility.InitilizeDirectories();
            _files = PathIterator.Iterate(_dir).ToArray();
        }
        public virtual void Dispose()
        {
            _dir.Delete(true);
        }
    }
}
