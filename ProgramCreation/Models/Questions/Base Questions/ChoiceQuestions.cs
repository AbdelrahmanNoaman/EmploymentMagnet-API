using ProgramCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models.Questions
{
    abstract class ChoiceQuestion : Question, IQuestion
    {
        private List<string> _choices;
        private bool _enableOther;

        public List<string> Choices
        {
            get { return _choices; }
            set { _choices = value; }
        }

        public bool EnableOther
        {
            get { return _enableOther; }
            set { _enableOther = value; }
        }
        public ChoiceQuestion(string id, string title, string sectionName, List<string> choices, bool enableOther) : base(id, title, sectionName)
        {
            this.Choices = choices;
            this.EnableOther = enableOther;
        }
    }
}
