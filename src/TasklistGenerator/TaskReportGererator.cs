using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace TasklistGenerator
{
    public class TaskReportGererator
    {
        private FileTaskExtractor _extractor;
        private ITaskTokenFormatter _formatter;

        public FileTaskExtractor Extractor
        {
            get { return _extractor; }
            set { _extractor = value; }
        }

        public ITaskTokenFormatter Formatter
        {
            get { return _formatter; }
            set { _formatter = value; }
        }

        public TaskReportGererator(FileTaskExtractor extractor, ITaskTokenFormatter formatter)
        {
            _extractor = extractor;
            _formatter = formatter;
        }

        public void GenerateReport(string[] files, string outputFile)
        {
            var sb = new StringBuilder();
            var tokens = _extractor.Extract(files);

            sb.AppendLine(_formatter.Format(tokens));


            using(var stream = new FileStream(outputFile, FileMode.Create))
            using (var wr = new StreamWriter(stream))
            {
                wr.Write(sb.ToString());
            }
        }


    }
}
