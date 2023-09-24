using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    //contains the program information that will be created once the user wants to add a new program
    public class ProgramInformationDTO
    {
        public string ProgramId { get; set; }
        public string FormId { get; set; }
        public string workFlowId { get; set; }

        public ProgramInformationDTO(string programId, string formId, string workflowId)
        {
            this.ProgramId = programId;
            this.FormId = formId;
            this.workFlowId = workflowId;
        }
    }
}
