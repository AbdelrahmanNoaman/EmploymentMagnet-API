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
            try
            {
                var result = await _container.ReadItemAsync<QuestionDTO>(questionInfo.id, new PartitionKey(questionInfo.Type));
                return result.Resource;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return null;
            }
        }

        public  async Task<QuestionInfoDTO> Add(QuestionDTO question)
        {
            question.id = Guid.NewGuid().ToString();
            try
            {
                IQuestion newQues = QuestionFactory.CreateQuestion(question);
                var result = await _container.CreateItemAsync(newQues);
                return new QuestionInfoDTO {id = ((Question)newQues).Id, Type=((Question)newQues).Type };
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return null;
            }
        }

        public async Task Delete(QuestionInfoDTO questionInfo)
        {
            try
            {
                var result = await _container.DeleteItemAsync<Object>(questionInfo.id, new PartitionKey(questionInfo.Type));
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public async Task ChangeQuestionHiddenState(QuestionInfoDTO questionInfo, bool state)
        {
                QuestionDTO question = await this.GetById(questionInfo);
                question.IsHidden = state;
                var finalResult = await _container.ReplaceItemAsync<QuestionDTO>(question, question.id, new PartitionKey(question.Type));
        }

        public async Task ChangeQuestionInternalState(QuestionInfoDTO questionInfo, bool state)
        {
            try
            {
                QuestionDTO question = await this.GetById(questionInfo);
                question.IsInternal = state;
                var finalResult = await _container.ReplaceItemAsync<QuestionDTO>(question, question.id, new PartitionKey(question.Type));

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }
        public async Task ChangeQuestionMandatoryState(QuestionInfoDTO questionInfo, bool state)
        {
            try
            {
                QuestionDTO question = await this.GetById(questionInfo);
                question.IsMandatory = state;
                var finalResult = await _container.ReplaceItemAsync<QuestionDTO>(question, question.id, new PartitionKey(question.Type));
            }
            catch (Exception error) { Console.WriteLine(error); }
        }
    }
}
