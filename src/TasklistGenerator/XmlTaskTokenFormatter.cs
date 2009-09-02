using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TasklistGenerator
{
    public class XmlTaskTokenFormatter : ITaskTokenFormatter
    {
        
        public string Format(IEnumerable<TaskToken> tokens)
        {

            var ret = new XElement("tasks",
                                   from token in tokens
                                   group token by token.File
                                   into gr
                                       select new XElement("file",
                                                           new XAttribute("name", gr.Key),
                                                           from tok in gr
                                                           select new XElement("task", 
                                                               tok.Text,
                                                               new XAttribute("type", tok.Name),
                                                               //new XAttribute("priority", tok.Priority),
                                                               new XAttribute("line", tok.Line))
                                       )
                );

            return ret.ToString();
                      
        }
    }
}