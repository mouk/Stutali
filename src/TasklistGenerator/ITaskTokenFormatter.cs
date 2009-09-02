using System;
using System.Collections.Generic;

namespace TasklistGenerator
{
    public interface ITaskTokenFormatter
    {
        string Format(IEnumerable<TaskToken> tokens);
    }
}
