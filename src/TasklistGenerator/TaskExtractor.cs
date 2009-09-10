using System;
using System.Text.RegularExpressions;

namespace TasklistGenerator
{
    public class TaskExtractor : ITaskExtractor
    {
        private readonly Regex _pattern; 

        public TaskExtractor(string taskName)
        {
            _pattern = new Regex(@"//\s?(?<Name>" + taskName + @")(?<Text>.*)");
        }

        public int Priority { get; set; }

        public TaskToken Extract(string line)
        {
            var match = _pattern.Match(line);
            if(!match.Success)
                return null;

            return new TaskToken
                       {
                           Name = match.Groups["Name"].Value,
                           Text = match.Groups["Text"].Value.Trim(),
                           Priority = Priority
                       };
        }
    }
}