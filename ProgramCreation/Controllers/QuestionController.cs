using ProgramCreation.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramCreation.Data.Repositories;
using ProgramCreation.Exceptions;

namespace ProgramCreation.Controllers
{
    [ApiController]
    public class QuestionController:Controller
    {
        private QuestionRepository _quesRepo = new();
        [Route("api/question/")]
        [HttpGet]
        public async Task<ResponseDTO<QuestionDTO>> GetQuestion(QuestionInfoDTO questionInfo)
        {
            try
            {
                QuestionDTO question = await _quesRepo.GetById(questionInfo);
                ResponseDTO<QuestionDTO> response = new(200, "Question Has Been Returned Successfully", question);
                return response;
            }
            catch (userDefinedException err)
            {
                ResponseDTO<QuestionDTO> response = new(err.StatusCode, err.Message, null);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<QuestionDTO> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/question/")]
        [HttpPost]
        public async Task<ResponseDTO<QuestionInfoDTO>> AddQuestion(QuestionDTO ques)
        {
            try
            {
                QuestionInfoDTO question = await _quesRepo.Add(ques);
                ResponseDTO<QuestionInfoDTO> response = new(200, "Question Has Been Added Successfully", question);
                return response;
            }
            catch(userDefinedException err)
            {
                ResponseDTO<QuestionInfoDTO> response = new(err.StatusCode,err.Message, null);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<QuestionInfoDTO> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/question/hide")]
        [HttpPut]
        public async Task<ResponseDTO<string>> HideQuestion(QuestionInfoDTO questionInfo)
        {
            try
            {
                await _quesRepo.ChangeQuestionHiddenState(questionInfo, true);
                ResponseDTO<string> response = new(200, "Question Has Been Hidden Successfully", "Hidden");
                return response;
            }
            catch (userDefinedException err)
            {
                ResponseDTO<string> response = new(err.StatusCode, err.Message, null);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<string> response = new(500, "Internal Server Error", "Cannot be Hidden");
                return response;
            }
        }

        [Route("api/question/unhide")]
        [HttpPut]
        public async Task<ResponseDTO<string>> UnhideQuestion(QuestionInfoDTO questionInfo)
        {
            try
            {
                await _quesRepo.ChangeQuestionHiddenState(questionInfo, false);
                ResponseDTO<string> response = new(200, "Question Has Been Unhidden Successfully", "Unhidden");
                return response;
            }
            catch (userDefinedException err)
            {
                ResponseDTO<string> response = new(err.StatusCode, err.Message, null);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<string> response = new(500, "Internal Server Error", "Cannot be Unhidden");
                return response;
            }
        }

        [Route("api/question/mandatory")]
        [HttpPut]
        public async Task<ResponseDTO<string>> MandatoryQuestion(QuestionInfoDTO questionInfo)
        {
            try
            {
                await _quesRepo.ChangeQuestionMandatoryState(questionInfo, true);
                ResponseDTO<string> response = new(200, "Question Has Been Marked as Mandatory Successfully", "Hidden");
                return response;
            }
            catch (userDefinedException err)
            {
                ResponseDTO<string> response = new(err.StatusCode, err.Message, null);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<string> response = new(500, "Internal Server Error", "Cannot be marked as Mandatory");
                return response;
            }
        }

        [Route("api/question/notMandatory")]
        [HttpPut]
        public async Task<ResponseDTO<string>> NotMandatoryQuestion(QuestionInfoDTO questionInfo)
        {
            try
            {
                await _quesRepo.ChangeQuestionMandatoryState(questionInfo, false);
                ResponseDTO<string> response = new(200, "Question Has Been Marked as Not Mandatory Successfully", "Unhidden");
                return response;
            }
            catch (userDefinedException err)
            {
                ResponseDTO<string> response = new(err.StatusCode, err.Message, null);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<string> response = new(500, "Internal Server Error", "Cannot be marked as not Mandatory");
                return response;
            }
        }
    }
}
