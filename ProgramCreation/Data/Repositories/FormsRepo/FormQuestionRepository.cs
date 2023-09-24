using ProgramCreation.Data.Repositories;
using ProgramCreation.DTOs;
using ProgramCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Data.Repositories
{
    public class FormQuestionRepository
    {
        private QuestionRepository _quesRepo = new();
        private FormRepository _formRepo = new();

        public async Task<FormDTO> GetFullInformation(string formId)
        {
            ProgramForm form = await _formRepo.GetById(formId);

            List<QuestionDTO> personalInformationQuestions = new List<QuestionDTO>();
            List<QuestionDTO> profileQuestions = new List<QuestionDTO>();
            List<QuestionDTO> additionalQuestions = new List<QuestionDTO>();

            foreach (QuestionInfoDTO questionInfo in form.QuestionsIds)
            {
                QuestionDTO question = await _quesRepo.GetById(questionInfo);
                switch (question.SectionName)
                {
                    case "Personal Information":
                        personalInformationQuestions.Add(question); break;
                    case "Profile":
                        profileQuestions.Add(question); break;
                    default:
                        additionalQuestions.Add(question); break;
                }
            }
            return new FormDTO(form, personalInformationQuestions, profileQuestions, additionalQuestions);
        }

    }
}
