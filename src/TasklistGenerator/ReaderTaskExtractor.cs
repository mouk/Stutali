using System.Collections.Generic;
using System.IO;

namespace TasklistGenerator
{
    public class ReaderTaskExtractor
    {
        private readonly IList<ITaskExtractor> _extractors;

        public ReaderTaskExtractor(IList<ITaskExtractor> extractors)
        {
            _extractors = extractors;
        }

        public IEnumerable<TaskToken> ExtractTokens(TextReader reader)
        {
            string line;
            int lineNumber = 0;
            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                foreach (var extractor in _extractors)
                {
                    var token = extractor.Extract(line);
                    if (token != null)
                    {
                        token.Line = lineNumber;
                        yield return token;
                    }
                }
            }
        }
    }
}