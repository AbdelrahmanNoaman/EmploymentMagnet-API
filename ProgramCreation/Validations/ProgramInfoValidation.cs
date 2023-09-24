using Microsoft.AspNetCore.Http;
using ProgramCreation.Data.Repositories;
using ProgramCreation.Data.Repositories.AdditionalDataRepo;
using ProgramCreation.DTOs;
using ProgramCreation.Exceptions;
using ProgramCreation.Interfaces;
using ProgramCreation.Models;


namespace ProgramCreation.Validations
{
    public class ProgramInfoValidation
    {

        public static void isProgramInfoExists(ProgramInfo programInfo)
        {
            if (programInfo == null)
                throw new userDefinedException(400, "This Program Info Doesn't Exist");
        }
        public async static Task Validate(ProgramInfo programInfo)
        {

            if(programInfo.Title ==null)
                throw new userDefinedException(400, "Program Title is required");
            if(programInfo.Description==null)
                throw new userDefinedException(400, "Program Description is required");
            if(programInfo.Type==null)
                throw new userDefinedException(400, "Program type is required");
            if(programInfo.ApplicationClose==null)
                throw new userDefinedException(400, "Application Close is required");
            if (programInfo.ApplicationOpen == null)
                throw new userDefinedException(400, "Application Open is required");
            if (programInfo.ProgramLocation == null)
                throw new userDefinedException(400, "Program Location is required");
            if (programInfo.FullyRemote == null)
                throw new userDefinedException(400, "Fully Remote is required");
            if (programInfo.MaxNumberOfApplication == null)
                throw new userDefinedException(400, "Max Number Of Applications is required");


            if(programInfo.Summary!= null && programInfo.Summary.Length > 250) 
                throw new userDefinedException(400, "Summary must be less than 250 letter");

            // Check on data types
            DateTime date;
            if (!DateTime.TryParse(programInfo.ApplicationClose,out date))
                throw new userDefinedException(400, "Application Close is not a valid date");
            if (!DateTime.TryParse(programInfo.ApplicationOpen, out date))
                throw new userDefinedException(400, "Application Open is not a valid date");
            if (programInfo.ProgramStart != null && !DateTime.TryParse(programInfo.ProgramStart, out date))
                throw new userDefinedException(400, "Program Start is not a valid date");


            //Check on Existance documents
            ProgramTypeRepository _typesrepo = new();
            List<ProgramType> types = await _typesrepo.GetAllTypes();

            bool found = false;
            foreach (var type in types)
            {
                if (type.Name == programInfo.Type)
                {
                    found = true; break;
                }
            } if(!found)
                throw new userDefinedException(400, "This Program value isn't valid");

            //Check on Existance documents
            MinqualificationRepository _qualificationsrepo = new();
            List<MinQualification> qualifications = await _qualificationsrepo.GetAllTypes();

            if (programInfo.MinQualification != null)
            {
                found = false;
                foreach (var type in types)
                {
                    if (type.Name == programInfo.MinQualification)
                    {
                        found = true; break;
                    }
                }
                if (!found)
                    throw new userDefinedException(400, "This Min Qualification isn't valid");
            }

        }

    }
}
