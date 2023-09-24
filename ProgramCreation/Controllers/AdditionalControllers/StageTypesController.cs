using Microsoft.AspNetCore.Mvc;
using ProgramCreation.Data.Repositories;
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
    public class FormController : Controller
    {
        private StagesTypeRepository _stageTypesRepo = new();

        [Route("api/stageTypes/")]
        [HttpGet]
        public async Task<ResponseDTO<List<StageType>>> GetAllTypes()
        {
            try
            {
                List < StageType > stages = await _stageTypesRepo.GetAllTypes();
                ResponseDTO<List<StageType>> response = new(200, "Stages Has Been Returned Successfully", stages);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<List<StageType>> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/stageTypes")]
        [HttpPost]
        public async Task<ResponseDTO<StageType>> AddStageType(StageType type)
        {
            try
            {
                await _stageTypesRepo.Add(type);
                ResponseDTO<StageType> response = new(200, "Question Has Been Added Successfully", type);
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
