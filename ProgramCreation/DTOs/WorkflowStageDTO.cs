using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Models.Stages;

namespace ProgramCreation.DTOs
{
    public class WorkflowStageDTO
    {
        public StageDTO? Stage { get; set; }
        public string workflowId { get; set; }
    }
}
