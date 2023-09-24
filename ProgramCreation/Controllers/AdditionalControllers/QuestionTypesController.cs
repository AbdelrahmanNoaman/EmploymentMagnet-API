using Microsoft.AspNetCore.Mvc;
using ProgramCreation.Data.Repositories;
using ProgramCreation.Data.Repositories.AdditionalDataRepo;
using ProgramCreation.DTOs;
using ProgramCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Controllers.AdditionalControllers
{
    [ApiController]
    public class QuestionTypesController : Controller
    {
        private QuestionTypeRepository _questionTypesRepo = new();

        [Route("api/questionTypes/")]
        [HttpGet]
        public async Task<ResponseDTO<List<QuestionTypes>>> GetAllTypes()
        {
            try
            {
                List<QuestionTypes> types = await _questionTypesRepo.GetAllTypes();
                ResponseDTO<List<QuestionTypes>> response = new(200, "Question Types Has Been Returned Successfully", types);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<List<QuestionTypes>> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/questionTypes/")]
        [HttpPost]
        public async Task<ResponseDTO<StageType>> AddStageType(QuestionTypes type)
        {
            try
            {
                await _questionTypesRepo.Add(type);
                ResponseDTO<StageType> response = new(200, "Question Type Has Been Added Successfully", type);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<StageType> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

    }
}
