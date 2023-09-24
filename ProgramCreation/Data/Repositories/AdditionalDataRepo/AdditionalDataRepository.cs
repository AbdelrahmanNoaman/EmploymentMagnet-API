using ProgramCreation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Data.Repositories.AdditionalDataRepo
{
    public interface AdditionalDataRepository<T>
    {

        public static async Task<List<T>> GetAllTypes(Microsoft.Azure.Cosmos.Container _container)
        {
            var result = _container.GetItemQueryIterator<T>("SELECT * FROM c");
            List<T> types = new List<T>();
            while (result.HasMoreResults)
            {
                var response = await result.ReadNextAsync();
                foreach (var item in response)
                {
                    types.Add(item);
                }
            }
            return types;
        }
    }
}
