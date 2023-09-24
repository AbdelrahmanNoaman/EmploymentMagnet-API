using ProgramCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    public class YesOrNoQuestion : Question, IQuestion
    {
        private bool _isDisqualified;

        public bool IsDisqualified
        {
            get { return this._isDisqualified; }
            set { this._isDisqualified = value; }
        }
        public YesOrNoQuestion(string id, string title, string sectionName ,bool isDisqualified) : base(id, title, sectionName)
        {
            this.Type = "Yes/No";
            this.IsDisqualified = isDisqualified == null ? isDisqualified : false;
        }
    }
}
