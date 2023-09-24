using Microsoft.AspNetCore.Http;
using ProgramCreation.Data.Repositories;
using ProgramCreation.Data.Repositories.AdditionalDataRepo;
using ProgramCreation.DTOs;
using ProgramCreation.Exceptions;
using ProgramCreation.Interfaces;
using ProgramCreation.Models;


namespace ProgramCreation.Validations
{
    public class StageValidation
    {

        public static void isStageExists(StageDTO stage)
        {
            if (stage == null)
                throw new userDefinedException(400, "This stage Doesn't Exist");
        }
        public async static Task Validate(StageDTO stage)
        {
            if(stage.Name==null)
                throw new userDefinedException(400, "Stage Name is required");
            if (stage.Type == null)
                throw new userDefinedException(400, "Stage Type is required");

            StagesTypeRepository _typesrepo = new();
            List<StageType> types = await _typesrepo.GetAllTypes();

            bool found = false;
            foreach (StageType type in types)
            {
                if (type.Name == stage.Type)
                {
                    found = true; break;
                }
            }
            if (found == false)
                throw new userDefinedException(400, "This is Not a valid Stage Type");

            if (stage.Type == "Video Interview" && stage.InterviewQuestion ==null)
                throw new userDefinedException(400, "Interview Question is required");
            if (stage.Type == "Video Interview" && stage.AdditionalInfo == null)
                throw new userDefinedException(400, "Addtional Info is required");
            if (stage.Type == "Video Interview" && stage.MaxDuration == null)
                throw new userDefinedException(400, "Max Duration is required");
            if (stage.Type == "Video Interview" && stage.TimeIn == null)
                throw new userDefinedException(400, "Time In is required");
            if (stage.Type == "Video Interview" && stage.NumberOfDaysLeft == null)
                throw new userDefinedException(400, "Number of Days Left is required");

            if (stage.Type == "Video Interview" && (stage.TimeIn != 0 || (int)stage.TimeIn != 1))
                throw new userDefinedException(400, "Time In Must be 0 or 1");


        }

    }
}
