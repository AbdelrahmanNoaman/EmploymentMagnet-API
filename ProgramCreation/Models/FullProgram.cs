using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Models.Forms;
using ProgramCreation.Models.ProgramInfo;

namespace ProgramCreation.Models
{
    public class FullProgram
    {
        private string _id;
        private string? _programInfoId;
        private string _programFormId;
        private string _programWorkflowId;

        public string id { get { return this._id; } set { this._id = value; } }
        public string ProgramInfoId { get { return this._programInfoId; } set { this._programInfoId = value; } }
        public string ProgramFormId { get { return this._programFormId; } set { this._programFormId = value; } }
        public string ProgramWorkflowId { get { return this._programWorkflowId; } set { this._programWorkflowId = value; } }

        public FullProgram(string id, string programInfoId,string programFormId,string programWorkflowId) 
        {
            this.id=id;
            this.ProgramFormId = programFormId;
            this.ProgramWorkflowId = programWorkflowId;
            this.ProgramInfoId = programInfoId;
        }

    }
}
