using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace TasklistGenerator.Tests.Integration
{
    public class FactoryTests : IntegrationBase
    {
        


        [Fact]
        public void CanDo()
        {
            Assert.NotNull(_theFactory.CreateFileTaskExtractor());
        }

        [Fact]
        public void ResolveTaskReportGererator_NoError()
        {
            Assert.NotNull(_theFactory.CreateTaskReportGererator());
        }

        [Fact]
        public void Extract_folderWithThreeFilesandTwoTaskts_TasksExtracted()
        {
            var extr = _theFactory.CreateFileTaskExtractor();
            var files = PathIterator.Iterate(_dir).ToArray();

            var result = extr.Extract(files).ToList();
            Assert.Equal(2,result.Count);
        }


        public void Dispose()
        {
            _dir.Delete(true);
        }
    }
}