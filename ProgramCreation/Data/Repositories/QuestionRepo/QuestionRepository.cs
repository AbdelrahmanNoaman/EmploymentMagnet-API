using ProgramCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Interfaces;
using ProgramCreation.DTOs;
using Microsoft.Azure.Cosmos;
using ProgramCreation.Validations;

namespace ProgramCreation.Data.Repositories
{
    public class QuestionRepository : IRepository<QuestionDTO, QuestionInfoDTO>
    {
        private Container _container = new DbContext().GetContainer("questions");

        public async Task<QuestionDTO> GetById(QuestionInfoDTO questionInfo)
        {

            var result = await _container.ReadItemAsync<QuestionDTO>(questionInfo.id, new PartitionKey(questionInfo.Type));
            QuestionValidation.IsQuestionExist(result.Resource);
            return result.Resource;
        }

        public async Task<QuestionInfoDTO> Add(QuestionDTO question)
        {
            await QuestionValidation.checkQuestionData(question);
            question.id = Guid.NewGuid().ToString();
            //IQuestion newQues = QuestionFactory.CreateQuestion(question);
            var result = await _container.CreateItemAsync(question);
            return new QuestionInfoDTO { id = question.id, Type = question.Type };
        }

        public async Task Delete(QuestionInfoDTO questionInfo)
        {
            QuestionDTO question = await GetById(questionInfo);
            var result = await _container.DeleteItemAsync<object>(questionInfo.id, new PartitionKey(questionInfo.Type));
        }

        public async Task ChangeQuestionHiddenState(QuestionInfoDTO questionInfo, bool state)
        {
            QuestionDTO question = await GetById(questionInfo);
            question.IsHidden = state;
            var finalResult = await _container.ReplaceItemAsync(question, question.id, new PartitionKey(question.Type));
        }

        public async Task ChangeQuestionInternalState(QuestionInfoDTO questionInfo, bool state)
        {
            QuestionDTO question = await GetById(questionInfo);
            question.IsInternal = state;
            var finalResult = await _container.ReplaceItemAsync(question, question.id, new PartitionKey(question.Type));
        }
        public async Task ChangeQuestionMandatoryState(QuestionInfoDTO questionInfo, bool state)
        {
            QuestionDTO question = await GetById(questionInfo);
            question.IsMandatory = state;
            var finalResult = await _container.ReplaceItemAsync(question, question.id, new PartitionKey(question.Type));
        }
    }
}
