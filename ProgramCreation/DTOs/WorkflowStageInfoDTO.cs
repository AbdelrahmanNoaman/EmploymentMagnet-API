using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    public class WorkflowStageInfoDTO
    {
        public StageInfoDTO? StageInfo { get; set; }
        public string WorkflowId { get; set; }
    }
}
