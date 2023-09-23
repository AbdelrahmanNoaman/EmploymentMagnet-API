using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Interfaces
{
    internal interface IRepository<OBJECT,INFO>
    {
        Task<OBJECT>    GetById (INFO info);
        Task<INFO>      Add     (OBJECT element);
        Task            Delete  (INFO element);
    }
}
