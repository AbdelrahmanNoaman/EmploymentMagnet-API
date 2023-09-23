using ProgramCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models.Questions
{
    public class DropdownQuestion : ChoiceQuestion, IQuestion
    {
        public DropdownQuestion(string id, string title, string sectionName, List<string> choices, bool enableOther) : base(id, title, sectionName, choices, enableOther)
        {
            this.Type = "Dropdown";
        }
    }
}
