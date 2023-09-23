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

namespace ProgramCreation.Data.Repositories
{
    public class QuestionRepository:IRepository<QuestionDTO,QuestionInfoDTO>
    {
        private  Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("questions");

        public  async Task<QuestionDTO> GetById(QuestionInfoDTO questionInfo)
        {

            var result = await _container.ReadItemAsync<QuestionDTO>(questionInfo.id, new PartitionKey(questionInfo.Type));
            return result.Resource;
        }

        public  async Task<QuestionInfoDTO> Add(QuestionDTO question)
        {
            question.id = Guid.NewGuid().ToString();
            //IQuestion newQues = QuestionFactory.CreateQuestion(question);
            var result = await _container.CreateItemAsync(question);
            return new QuestionInfoDTO { id = question.id, Type = question.Type };
        }

        public async Task Delete(QuestionInfoDTO questionInfo)
        {
            var result = await _container.DeleteItemAsync<Object>(questionInfo.id, new PartitionKey(questionInfo.Type));
        }

        public async Task ChangeQuestionHiddenState(QuestionInfoDTO questionInfo, bool state)
        {
            QuestionDTO question = await this.GetById(questionInfo);
            question.IsHidden = state;
            var finalResult = await _container.ReplaceItemAsync<QuestionDTO>(question, question.id, new PartitionKey(question.Type));
        }

        public async Task ChangeQuestionInternalState(QuestionInfoDTO questionInfo, bool state)
        {
            QuestionDTO question = await this.GetById(questionInfo);
            question.IsInternal = state;
            var finalResult = await _container.ReplaceItemAsync<QuestionDTO>(question, question.id, new PartitionKey(question.Type));

        }
        public async Task ChangeQuestionMandatoryState(QuestionInfoDTO questionInfo, bool state)
        {
            QuestionDTO question = await this.GetById(questionInfo);
            question.IsMandatory = state;
            var finalResult = await _container.ReplaceItemAsync<QuestionDTO>(question, question.id, new PartitionKey(question.Type));

        }
    }
}
