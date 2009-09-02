using System.Collections.Generic;
using System.IO;

namespace TasklistGenerator
{
    public class FileTaskExtractor
    {
        private ReaderTaskExtractor _readerTaskExtractor;

        public FileTaskExtractor(ReaderTaskExtractor readerTaskExtractor)
        {
            _readerTaskExtractor = readerTaskExtractor;
        }

        public IEnumerable<TaskToken> Extract(string[] files)
        {
            foreach (var file in files)
            {
                using (var reader = new StreamReader(file))
                {
                    foreach (var token in _readerTaskExtractor.ExtractTokens(reader))
                    {
                        token.File = file;
                        yield return token;
                    }
                }

            }
            
        }

    }
}