using ProgramCreation.Data.Repositories;
using ProgramCreation.Data.Repositories.AdditionalDataRepo;
using ProgramCreation.DTOs;
using ProgramCreation.Exceptions;
using ProgramCreation.Models;


namespace ProgramCreation.Validations
{
    public class FormValidation
    {

        public  static void checkForQuestionInfo(QuestionInfoDTO question)
        {
            if (question.id == null) 
                throw new userDefinedException(400, "Question id is Required");
            if(question.Type==null)
                throw new userDefinedException(400, "Question Type is Required");

        }

        public  static void checkForForm(ProgramForm form)
        {
            if (form == null)
                throw new userDefinedException(400, "This Form Doesn't Exist");
        }
        public async static Task checkForQuestionAdd(string formId, QuestionInfoDTO question)
        {
            FormRepository formRepository = new();
            ProgramForm form = await formRepository.GetById(formId);

            foreach( QuestionInfoDTO quesId in form.QuestionsIds)
            {
                if (quesId.id == question.id)
                {
                    throw new userDefinedException(400, "This Question Already Exists");
                }
            }
        }

        public async static Task checkForQuestionRemove(string formId, QuestionInfoDTO question)
        {
            FormRepository formRepository = new();
            ProgramForm form = await formRepository.GetById(formId);
            bool found = false;
            foreach (QuestionInfoDTO quesId in form.QuestionsIds)
            {
                if (quesId.id == question.id)
                {
                    found = true; break;
                }
            }
            if (found == false)
            {
                throw new userDefinedException(400, "This Question Doesn't Exist");

            }
        }
    }
}
