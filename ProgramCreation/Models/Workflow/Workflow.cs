using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.DTOs;
using ProgramCreation.Models.Stages.Base_Stages;

namespace ProgramCreation.Models.Workflow
{
    public class Workflow
    {
        public string id { get; set; }
        public List<StageInfoDTO> Stages { get; set; }
        public Workflow(List<StageInfoDTO> stages, string id)
        {
            this.Stages = stages;
            this.id = id;
        }
    }
}
