using ProgramCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Models;

namespace ProgramCreation.DTOs
{
    //Contains all the data of the workflow not only the ids of the stages, but the ids and the stages themselves 
    public class WorkflowDTO
    {

        public string id { get; set; }
        public List<StageDTO> Stages { get; set; }
        public List<StageType> Types { get; set; }

        public WorkflowDTO(string id, List<StageDTO> stages, List<StageType> types)
        {
            this.id = id;
            this.Stages = stages;
            this.Types = types;
        }

    }
}
