using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TasklistGenerator
{
    public class TaskTokenFormatter : ITaskTokenFormatter
    {
        public string Format(TaskToken token)
        {
            return string.Format(
                "<li><i>{0}:</i><b>{1}</b> (Line:{2})</li>\n",
                token.Name,
                token.Text,
                token.Line
                );
        }

        public string Format(IEnumerable<TaskToken> tokens)
        {
            var sb = new StringBuilder();
            foreach (var grouping in tokens.GroupBy(t=>t.File))
            {
                sb.AppendLine("<h3>" + grouping.Key + "</h3>");
                sb.AppendLine("<ul>");
                foreach (var token in grouping.OrderBy(tok => tok.Line))
                {
                    sb.AppendLine(Format(token));
                }
                sb.AppendLine("</ul>");
            }
            return sb.ToString();
        }
    }
}