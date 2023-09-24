using Microsoft.AspNetCore.Mvc;
using ProgramCreation.Data.Repositories;
using ProgramCreation.DTOs;
using ProgramCreation.Models;
using ProgramCreation.Models.Forms;
using ProgramCreation.Models.ProgramInfo;
using ProgramCreation.Models.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Controllers
{
    [ApiController]
    public class ProgramController : Controller
    {
        private FormRepository _formRepo = new();
        private WorkflowRepository _workflowRepo = new();
        private ProgramRepository _programRepo = new();
        private ProgramInfoRepository _programInfoRepo = new();

        private FormQuestionRepository _formQuesRepo = new();
        private WorkflowStageRepository _workflowStageRepo = new();

        [Route("api/program/")]
        [HttpGet]
        public async Task<ResponseDTO<ProgramDTO>> GetForm(ObjectWithId programObject)
        {
            try
            {
                FullProgram program = await _programRepo.GetById(programObject.id);
                FormDTO programForm = await _formQuesRepo.GetFullInformation(program?.ProgramFormId);
                ProgramInfo programInfo = await _programInfoRepo.GetById(program?.ProgramInfoId);
                WorkflowDTO ProgramWorkflow = await _workflowStageRepo.GetFullInformation(program?.ProgramWorkflowId);

                ProgramDTO finalProgram = new ProgramDTO(program.id, programInfo, programForm, ProgramWorkflow);
                ResponseDTO<ProgramDTO> response = new(200, "Program Has Been Returned Successfully", finalProgram);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<ProgramDTO> response = new(500, "Internal Server Error", null);
                return response;
            }
        }

        [Route("api/program")]
        [HttpPost]
        public async Task<ResponseDTO<ProgramInformationDTO>> AddProgram()
        {
            try
            {
                ProgramForm newForm = new ProgramForm();
                Workflow newWorkflow = new Workflow();
                string formId = await _formRepo.Add(newForm);
                string workflowId = await _workflowRepo.Add(newWorkflow);


                FullProgram newProgram = new FullProgram(null,null,formId,workflowId);
                string programId = await _programRepo.Add(newProgram);

                ProgramInformationDTO finalProgram = new(programId, formId, workflowId);

                ResponseDTO<ProgramInformationDTO> response = new(200, "Program Has Been Added Successfully", finalProgram);
                return response;
            }
            catch (Exception error)
            {
                ResponseDTO<ProgramInformationDTO> response = new(500, "Internal Server Error", null);
                return response;
            }
        }
    }
}
