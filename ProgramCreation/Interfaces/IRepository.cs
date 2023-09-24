using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Interfaces
{
    //Interface that holds those methods as all of them shoul be implemeneted in Repository of each type with the same format
    public interface IRepository<OBJECT,INFO>
    {
        Task<OBJECT>    GetById (INFO info);
        Task<INFO>      Add     (OBJECT element);
        Task            Delete  (INFO element);
    }
}
