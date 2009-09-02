using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Moq;

using Xunit;

namespace TasklistGenerator.Tests
{

    public class TaskManagerTests : IDisposable
    {
        private ReaderTaskExtractor _theExtractor;

        private Mock<ITaskExtractor> _extractorMock;

        
        public TaskManagerTests()
        {
            _extractorMock = new Mock<ITaskExtractor>();
            _theExtractor = new ReaderTaskExtractor(new[] { _extractorMock.Object});
        }

   

        [Fact]
        public void Extract_ReaderOfthreeLines_ExtractIsCalledOnEachLine_UsingMoq()
        {
            var lines = new List<string>
                            {
                                "first line",
                                "second line",
                                "third line"
                            };

            var text = lines.Aggregate((a, b) => a + "\n" + b);


            _extractorMock.Setup(ext => ext.Extract(It.IsAny<string>())).Callback(
                (string line) =>
                    {
                        Assert.Contains(line, lines);
                        lines.Remove(line);
                    }
                );

            using (var reader = new StringReader(text))
            {

                _theExtractor.ExtractTokens(reader).ToList();
            }

            Assert.Empty(lines);
        }



        public void Dispose()
        {
        }
    }
}
