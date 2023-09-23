using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Models.Stages.Base_Stages;

namespace ProgramCreation.Models.Workflow
{
    public class Workflow
    {
        public List<Stage> Stages { get; set; }
        public Workflow(List<Stage> stages)
        {
            this.Stages = stages;
        }
    }
}
