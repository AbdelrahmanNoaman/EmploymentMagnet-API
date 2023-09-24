using ProgramCreation.Models.Forms;
using ProgramCreation.Models.ProgramInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    public class ProgramDTO
    {

        public string id { get; set; }
        public ProgramInfo ProgramInfo{ get; set; }
        public FormDTO ProgramForm { get; set; }
        public WorkflowDTO ProgramWorkflow { get; set; }

        public ProgramDTO(string id, ProgramInfo programInfoId, FormDTO programFormId, WorkflowDTO programWorkflowId)
        {
            this.id = id;
            this.ProgramForm = programFormId;
            this.ProgramWorkflow = programWorkflowId;
            this.ProgramInfo = programInfoId;
        }
    }
}
