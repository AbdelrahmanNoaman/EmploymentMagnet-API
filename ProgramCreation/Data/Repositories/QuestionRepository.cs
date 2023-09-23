using ProgramCreation.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Interfaces;
using ProgramCreation.DTOs;

namespace ProgramCreation.Data.Repositories
{
    internal class QuestionRepository:IRepository<QuestionDTO>
    {
        public static QuestionDTO GetById(string id)
        {

        }
    }
}
