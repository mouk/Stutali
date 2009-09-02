using System;
using System.Linq;
using System.IO;
using System.Security;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;


namespace TasklistGenerator
{
    public class Tasklist : Task
    {

        [Required]
        public ITaskItem[] Files { get; set; }

        [Required]
        public ITaskItem OutputFile { get; set; }

        //TODO documentation
        public override bool Execute()
        {
            var fileTaskExtractor = new Factory().CreateTaskReportGererator();

            var files = Files
                .Select(task => task.ItemSpec)
                .Where(spec => spec.Length > 0)
                .ToArray();

            fileTaskExtractor.GenerateReport(files, OutputFile.ItemSpec);



            // Log.HasLoggedErrors is true if the task logged any errors -- even if they were logged 
            // from a task's constructor or property setter. As long as this task is written to always log an error
            // when it fails, we can reliably return HasLoggedErrors.
            return !Log.HasLoggedErrors;

        }
    }
}
