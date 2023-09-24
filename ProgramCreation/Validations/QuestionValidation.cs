using ProgramCreation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.DTOs;
using ProgramCreation.Data.Repositories.AdditionalDataRepo;
using ProgramCreation.Models;

namespace ProgramCreation.Validations
{
    public class QuestionValidation
    {
        public static void IsQuestionExist(QuestionDTO question)
        {
            if (question == null) 
            {
                throw new userDefinedException(400, "This Question Doesn't Exist");
            }
        }

        public async static Task checkQuestionData(QuestionDTO question)
        {
            if (question == null) 
            {
                throw new userDefinedException(400, "This Question Doesn't Exist");
            }

            if(question.Title == null)
                throw new userDefinedException(400, "Question Title is Required");
            if (question.Type == null)
                throw new userDefinedException(400, "Question Type is Required");
            if (question.SectionName == null)
                throw new userDefinedException(400, "Question Section Name is Required");

            if(question.SectionName!="Additional Question" && question.SectionName != "Personal Information" &&question.SectionName != "Profile")
                throw new userDefinedException(400, "Question Section Name Must be one of the following : Additional Question,Personal Information and Profile");

            QuestionTypeRepository _typesrepo = new();
            List<QuestionTypes> types = await _typesrepo.GetAllTypes();

            bool found = false;
            foreach (QuestionTypes type in types) {
                if (type.Name == question.Type)
                {
                    found = true;break;
                }
            }
            if(found==false)
                throw new userDefinedException(400, "This is Not a valid Question Type");

            if((question.Type=="Multiple choice" || question.Type == "Dropdown")&& question.Choices == null)
                 throw new userDefinedException(400, "Choices are required as you chose a choice question");
            
            if (question.Type == "Yes/No" && question.IsDisqualified == null)
                throw new userDefinedException(400, "IsDisqualified is required");

            if (question.SectionName == "Profile" && question.IsHidden == null)
                throw new userDefinedException(400, "isHidden is required");
            
            if (question.SectionName == "Profile" && question.IsMandatory == null)
                throw new userDefinedException(400, "isMandatory is required");



        }
    }
}
