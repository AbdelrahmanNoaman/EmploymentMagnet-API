using ProgramCreation.Models.Questions;
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

namespace ProgramCreation.Data.Repositories
{
    public class FormRepository : IRepository<ProgramForm, string>
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("forms");

        public async Task<ProgramForm> GetById(string formId)
        {
            var result = await _container.ReadItemAsync<ProgramForm>(formId, new PartitionKey(formId));
            return result.Resource;
        }

        public async Task<String> Add(ProgramForm form)
        {
            form.id = Guid.NewGuid().ToString();
            try
            {
                var result = await _container.CreateItemAsync(form);
                return form.id;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return null;
            }
        }

        public async Task Delete(string formId)
        {
            try
            {
                var result = await _container.DeleteItemAsync<Object>(formId, new PartitionKey(formId));
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }
        public async Task AddQuestion(string formId,QuestionInfoDTO quesInfo) {
            ProgramForm form = await this.GetById(formId);
            form.QuestionsIds.Add(quesInfo);
            await _container.ReplaceItemAsync<ProgramForm>(form, formId, new PartitionKey(formId));
        }

        public async Task DeleteQuestion(string formId, QuestionInfoDTO quesInfo)
        {
            ProgramForm form = await this.GetById(formId);
            form.QuestionsIds.Remove(quesInfo);
            await _container.ReplaceItemAsync<ProgramForm>(form, formId, new PartitionKey(formId));
        }
    }
}
