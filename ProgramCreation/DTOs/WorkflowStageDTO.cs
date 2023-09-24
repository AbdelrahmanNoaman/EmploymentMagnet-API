
using ProgramCreation.Models;

namespace ProgramCreation.DTOs
{
    public class WorkflowStageDTO
    {
        public StageDTO? Stage { get; set; }
        public string workflowId { get; set; }
    }
}
