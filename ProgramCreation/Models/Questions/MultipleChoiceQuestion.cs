using ProgramCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models.Questions
{
    public class MultipleChoiceQuestion : ChoiceQuestion, IQuestion
    {

        private int _maxChoiceAllowed;

        public int MaxChoiceAllowed
        {
            get { return _maxChoiceAllowed; }
            set { _maxChoiceAllowed = value; }
        }

        public MultipleChoiceQuestion(string id, string title, string sectionName, List<string> choices, bool enableOther, int maxChoiceAllowed) : base(id, title, sectionName, choices, enableOther)
        {
            this.MaxChoiceAllowed = maxChoiceAllowed;
            this.Type = "Multiple choice";
        }
    }
}
