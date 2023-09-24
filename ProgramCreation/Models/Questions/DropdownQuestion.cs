using ProgramCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    //Dropdown question is a special king that contains multiple choice and you should only choose one of them
    public class DropdownQuestion : ChoiceQuestion, IQuestion
    {
        public DropdownQuestion(string id, string title, string sectionName, List<string> choices, bool enableOther) : base(id, title, sectionName, choices, enableOther)
        {
            this.Type = "Dropdown";
        }
    }
}
