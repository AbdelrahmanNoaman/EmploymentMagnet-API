using ProgramCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models.Questions
{
    internal class NormalQuestion:Question,IQuestion
    {
        public NormalQuestion(string id, string title, string sectionName, string type) :base(id, title, sectionName)
        {
            this.Type= type;
        }
    }
}
