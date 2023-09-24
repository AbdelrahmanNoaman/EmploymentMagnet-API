using Microsoft.AspNetCore.Mvc;
using ProgramCreation.Data.Repositories;
using ProgramCreation.DTOs;
using ProgramCreation.Models;


namespace ProgramCreation.Controllers
{
    [ApiController]
    public class FormController:Controller
    {
        private QuestionRepository _quesRepo = new();
        private FormRepository _formRepo = new();
        private FormQuestionRepository _formQuesRepo = new();

        [Route("api/form/")]
        [HttpGet]
        public async Task<ResponseDTO<FormDTO>> GetForm(FormQuesInfoDTO formQues)
        {
            try
            {
                FormDTO ResultantForm = await _formQuesRepo.GetFullInformation(formQues.FormId);
                ResponseDTO<FormDTO> response = new(200, "Form Has Been Returned Successfully", ResultantForm);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<FormDTO> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/form/addQuestion")]
        [HttpPut]
        public async Task<ResponseDTO<QuestionInfoDTO>> AddQuestion(FormQuestionDTO ques)
        {
            try
            {
                QuestionInfoDTO question = await _quesRepo.Add(ques.Question);
                await _formRepo.AddQuestion(ques.FormId,question);
                ResponseDTO<QuestionInfoDTO> response = new(200, "Question Has Been Added Successfully", question);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<QuestionInfoDTO> response = new(500, "Internal Server Error", null);
                return response;
            }
        }


        [Route("api/form/removeQuestion")]
        [HttpPut]
        public async Task<ResponseDTO<string>> RemoveQuestion(FormQuesInfoDTO ques)
        {
            try
            {
                await _formRepo.DeleteQuestion(ques.FormId, ques.QuestionInfo);
                await _quesRepo.Delete(ques.QuestionInfo);
                ResponseDTO<string> response = new(200, "Question Has Been Deleted Successfully", "Deleted");
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<string> response = new(500, "Internal Server Error", "Not Deleted");
                return response;
            }
        }
    }
}
