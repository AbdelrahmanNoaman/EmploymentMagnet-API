using ProgramCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    //Base class for Choice questions like Multiple Choice and Dropdown
    //as the both have the properties of choices and enable others
    //then it would be better to set them together in that base class and they would both inherit from it
    public abstract class ChoiceQuestion : Question, IQuestion
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
