using ProgramCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Interfaces;
using ProgramCreation.DTOs;
using Microsoft.Azure.Cosmos;

namespace ProgramCreation.Data.Repositories
{
    public class FormRepository : IRepository<ProgramForm, string>
    {
        private Container _container = new DbContext().GetContainer("forms");

        public async Task<ProgramForm> GetById(string formId)
        {
            var result = await _container.ReadItemAsync<ProgramForm>(formId, new PartitionKey(formId));
            return result.Resource;
        }



        public async Task<string> Add(ProgramForm form)
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
                var result = await _container.DeleteItemAsync<object>(formId, new PartitionKey(formId));
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }
        public async Task AddQuestion(string formId, QuestionInfoDTO quesInfo)
        {
            ProgramForm form = await GetById(formId);
            form.QuestionsIds.Add(quesInfo);
            await _container.ReplaceItemAsync(form, formId, new PartitionKey(formId));
        }

        public async Task DeleteQuestion(string formId, QuestionInfoDTO quesInfo)
        {
            ProgramForm form = await GetById(formId);
            form.QuestionsIds.RemoveAll(info => info.id == quesInfo.id && info.Type == quesInfo.Type);
            await _container.ReplaceItemAsync(form, formId, new PartitionKey(formId));
        }
    }
}
