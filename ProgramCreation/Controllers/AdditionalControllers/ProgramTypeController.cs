using Microsoft.AspNetCore.Mvc;
using ProgramCreation.Data.Repositories.AdditionalDataRepo;
using ProgramCreation.DTOs;
using ProgramCreation.Models;

namespace ProgramCreation.Controllers.AdditionalControllers
{
    [ApiController]
    public class ProgramsTypeController : Controller
    {
        private ProgramTypeRepository _programTypeRepository = new();

        [Route("api/programTypes/")]
        [HttpGet]
        public async Task<ResponseDTO<List<ProgramType>>> GetAllTypes()
        {
            try
            {
                List<ProgramType> programs = await _programTypeRepository.GetAllTypes();
                ResponseDTO<List<ProgramType>> response = new(200, "Program Types Has Been Returned Successfully", programs);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<List<ProgramType>> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/programTypes/")]
        [HttpPost]
        public async Task<ResponseDTO<ProgramType>> AddStageType(ProgramType type)
        {
            try
            {
                await _programTypeRepository.Add(type);
                ResponseDTO<ProgramType> response = new(200, "Program Type Has Been Added Successfully", type);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<ProgramType> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

    }
}