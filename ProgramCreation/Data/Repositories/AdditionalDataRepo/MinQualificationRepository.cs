using ProgramCreation.Models;
using Microsoft.Azure.Cosmos;

namespace ProgramCreation.Data.Repositories.AdditionalDataRepo
{
    public class MinqualificationRepository
    {
        private Microsoft.Azure.Cosmos.Container _container = new DbContext().GetContainer("minqualifications");

        public async Task<List<MinQualification>> GetAllTypes()
        {
            return await AdditionalDataRepository<MinQualification>.GetAllTypes(_container);
        }

        public async Task Add(MinQualification qualification)
        {
            qualification.id = Guid.NewGuid().ToString();
            var result = await _container.CreateItemAsync(qualification);
        }

        public async Task Delete(MinQualification qualification)
        {
            await _container.DeleteItemAsync<Object>(qualification.id, new PartitionKey(qualification.id));
        }
    }
}
