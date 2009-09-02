using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace TasklistGenerator.Tests.Integration
{
    public class TaskReportGereratorTests : IntegrationBase
    {
        
        [Fact]
        public void Cando()
        {
            var reporter = _theFactory.CreateTaskReportGererator();
            reporter.Formatter = new XmlTaskTokenFormatter();
            string html = "output.html";
            reporter.GenerateReport(_files, html);
            using (var reader = new StreamReader(html, Encoding.UTF8))
                Console.WriteLine(reader.ReadToEnd());
        }

        
    }
}
