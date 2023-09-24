using ProgramCreation.Models;


namespace ProgramCreation.DTOs
{
    //DTO that is used to send all the needed details about a program not only ids of its components
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
