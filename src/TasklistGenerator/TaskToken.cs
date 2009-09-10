using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TasklistGenerator
{

    public class TaskToken
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Text { get; set; }
        public string File { get; set; }
        public int Line { get; set; }
    }
}
