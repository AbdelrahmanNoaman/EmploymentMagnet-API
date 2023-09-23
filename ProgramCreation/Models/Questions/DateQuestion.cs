using ProgramCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models.Questions
{
    internal class DateQuestion : Question, IQuestion
    {
        public DateQuestion(string id, string title, string sectionName) : base(id, title, sectionName)
        {
            this.Type = "Date";
        }
    }
}
