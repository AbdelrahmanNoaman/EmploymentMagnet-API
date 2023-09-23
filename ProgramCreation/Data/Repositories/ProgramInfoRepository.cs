using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Interfaces;
using ProgramCreation.DTOs;
using Microsoft.Azure.Cosmos;
using ProgramCreation.Models.Factory;
using ProgramCreation.Models.Forms;
using ProgramCreation.Models.ProgramInfo;
using ProgramCreation.Models.Questions;

namespace ProgramCreation.Data.Repositories
{
    public class ProgramInfoRepository: IRepository<ProgramInfo, string>
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("programinfo");


        public async Task<ProgramInfo> GetById(string programInfoId)
        {
            var result = await _container.ReadItemAsync<ProgramInfo>(programInfoId, new PartitionKey(programInfoId));
            return result.Resource;
        }

        public async Task<String> Add(ProgramInfo programInfo)
        {
            programInfo.id = Guid.NewGuid().ToString();
            var result = await _container.CreateItemAsync(programInfo);
            return programInfo.id;
        }

        public async Task Delete(string programId)
        {
            var result = await _container.DeleteItemAsync<Object>(programId, new PartitionKey(programId));
        }

        public async Task Update(ProgramInfo programInfo)
        {
            ProgramInfo result = await _container.ReadItemAsync<ProgramInfo>(programInfo.id, new PartitionKey(programInfo.id));
            result = programInfo;
            var finalResult = await _container.ReplaceItemAsync<ProgramInfo>(programInfo, programInfo.id, new PartitionKey(programInfo.id));
        }
    }
}
