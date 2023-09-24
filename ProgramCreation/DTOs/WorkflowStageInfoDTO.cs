using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    //Containg the information of the stage and the workload it should be in as this data will be added to the workflow itself
    public class WorkflowStageInfoDTO
    {
        public StageInfoDTO? StageInfo { get; set; }
        public string WorkflowId { get; set; }
    }
}
