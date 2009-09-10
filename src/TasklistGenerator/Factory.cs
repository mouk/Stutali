using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace TasklistGenerator
{
    public class Factory 
    {
        private Container container;
        public Factory()
        {
            container = new Container(registry =>
                                          {
                                              registry.Scan(x =>
                                                                {

                                                                    x.TheCallingAssembly();

                                                                    x.With<DefaultConventionScanner>();



                                                                });
                                              registry.BuildInstancesOf<IList<ITaskExtractor>>()
                                                  .AddInstances(ding
                                                                => ding.IsThis(new[]
                                                                                   {
                                                                                       new TaskExtractor("TODO"){Priority = 1},
                                                                                       new TaskExtractor("HACK"){Priority = 1},
                                                                                       new TaskExtractor("FIXME"){Priority = 1}
                                                                                   })
                                                  );

                                          }



                );
           
        }

        public FileTaskExtractor CreateFileTaskExtractor()
        {
            return container.GetInstance<FileTaskExtractor>();
        }
        public TaskReportGererator CreateTaskReportGererator()
        {
            return container.GetInstance<TaskReportGererator>();
        }

    }
}
