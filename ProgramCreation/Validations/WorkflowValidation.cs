using ProgramCreation.Data.Repositories;
using ProgramCreation.Data.Repositories.AdditionalDataRepo;
using ProgramCreation.DTOs;
using ProgramCreation.Exceptions;
using ProgramCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Validations
{
    public class WorkflowValidation
    {
        public static void IsworkflowExist(Workflow workflow)
        {
            if (workflow == null)
            {
                throw new userDefinedException(400, "This Workflow Doesn't Exist");
            }
        }
        public async static Task CheckForStageAdd(Workflow workflow, StageInfoDTO stage)
        {
            foreach (StageInfoDTO stageId in workflow.Stages)
            {
                if (stageId.id == stage.id)
                {
                    throw new userDefinedException(400, "This Stage Already Exists");
                }
            }
        }

        public async static Task CheckForStageRemove(Workflow workflow, StageInfoDTO stage)
        {
            foreach (StageInfoDTO stageId in workflow.Stages)
            {
                if (stageId.id == stage.id)
                {
                    return;
                }
            }
            throw new userDefinedException(400, "This Stage Doesn't Exist in That workflow");

        }
    }
}
