using Microsoft.AspNetCore.Mvc;
using ProgramCreation.Data.Repositories;
using ProgramCreation.DTOs;
using ProgramCreation.Models;
using ProgramCreation.Models.ProgramInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Controllers
{
    [ApiController]
    public class ProgramInfoController:Controller
    {
        private ProgramInfoRepository _infoRepo = new();
        private ProgramRepository _programRepo = new();

        [Route("api/programInfo/")]
        [HttpGet]
        public async Task<ResponseDTO<ProgramInfo>> GetProgramInfo(ObjectWithId programInfoId)
        {
            try
            {
                ProgramInfo programInfo = await _infoRepo.GetById(programInfoId.id);
                ResponseDTO<ProgramInfo> response = new(200, "Program Info Has Been Returned Successfully", programInfo);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<ProgramInfo> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/programInfo/")]
        [HttpPost]
        public async Task<ResponseDTO<ObjectWithId>> AddProgramInfo(ProgramInfoDTO program)
        {
            try
            {
                string programInfoId = await _infoRepo.Add(program.programInfo);
                await _programRepo.AddProgramInfo(programInfoId, program.ProgramId);
                ResponseDTO<ObjectWithId> response = new(200, "Program Info Has Been Added Successfully", new ObjectWithId(programInfoId));
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<ObjectWithId> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/programInfo/")]
        [HttpPut]
        public async Task<ResponseDTO<ProgramInfo>> UpdateProgramInfo(ProgramInfo questionInfo)
        {
            try
            {
                ProgramInfo newProgramInfo= await _infoRepo.Update(questionInfo);
                ResponseDTO <ProgramInfo> response = new(200, "Question Has Been Hidden Successfully", newProgramInfo);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<ProgramInfo> response = new(500, "Internal Server Error", null);
                return response;
            }
        }
    }
}
