using ProgramCreation.Models.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Models.Stages;

namespace ProgramCreation.DTOs
{
    public class WorkflowDTO
    {
        public Workflow stages { get; set; }

        public List<StageType> types { get; set; }


    }
}
