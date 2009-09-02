using System;
using System.IO;
using System.Linq;
using System.Text;
using Moq;
using Xunit;

namespace TasklistGenerator.Tests
{
    public class FileTaskExtractorTests :IDisposable
    {
        private FileTaskExtractor _theFileExtractor;
        private DirectoryInfo _dir;

        public FileTaskExtractorTests()
        {
            var readerMock = new Mock<ReaderTaskExtractor>();
            _dir = FolderUtility.InitilizeDirectories();

            _theFileExtractor = new FileTaskExtractor(readerMock.Object);
        }

        


        public void Dispose()
        {
            _dir.Delete(true);
        }
    }
}
