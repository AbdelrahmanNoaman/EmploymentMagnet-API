using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Interfaces;

namespace ProgramCreation.Models.Questions
{
    internal class ShortAnswerQuestion:Question,IQuestion
    {
        public ShortAnswerQuestion(string id, string title, string sectionName) : base(id, title, sectionName)
        {
            this.Type = "Short answer";
        }
    }
}
