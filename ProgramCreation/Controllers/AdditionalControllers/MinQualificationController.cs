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
    public class MinQualificationController : Controller
    {
        private MinqualificationRepository _minQualificationRepo = new();

        [Route("api/minQualification/")]
        [HttpGet]
        public async Task<ResponseDTO<List<MinQualification>>> GetAllTypes()
        {
            try
            {
                List<MinQualification> qualifications = await _minQualificationRepo.GetAllTypes();
                ResponseDTO<List<MinQualification>> response = new(200, "Min Qualifications Has Been Returned Successfully", qualifications);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<List<MinQualification>> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/minQualification/")]
        [HttpPost]
        public async Task<ResponseDTO<MinQualification>> AddStageType(MinQualification qualification)
        {
            try
            {
                await _minQualificationRepo.Add(qualification);
                ResponseDTO<MinQualification> response = new(200, "Min Qualification Has Been Added Successfully", qualification);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<MinQualification> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

    }
}
