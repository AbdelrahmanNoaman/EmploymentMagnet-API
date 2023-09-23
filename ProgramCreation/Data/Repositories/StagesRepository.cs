using ProgramCreation.DTOs;
using ProgramCreation.Interfaces;
using ProgramCreation.Models.Stages.Base_Stages;
using Microsoft.Azure.Cosmos;
namespace ProgramCreation.Data.Repositories
{
    public class StagesRepository:IRepository<Stage,StageInfoDTO>
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("stages");

        public async Task<Stage> GetById(StageInfoDTO StageInfo)
        {

            var result = await _container.ReadItemAsync<Stage>(StageInfo.id, new PartitionKey(StageInfo.Type));
            return result.Resource;
        }

        public async Task<QuestionInfoDTO> Add(Stage stage)
        {
            stage.id = Guid.NewGuid().ToString();
            //IQuestion newQues = QuestionFactory.CreateQuestion(question);
            var result = await _container.CreateItemAsync(stage);
            return new QuestionInfoDTO { id = stage.id, Type = stage.Type };
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