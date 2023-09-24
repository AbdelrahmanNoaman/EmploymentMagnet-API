using ProgramCreation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    //This is the general case it holds many types
    //like paragraph,shor answer, Date , Number and many others
    //all of them share the same attributes but they are changing in the type only
    public class NormalQuestion:Question,IQuestion
    {
        public NormalQuestion(string id, string title, string sectionName, string type) :base(id, title, sectionName)
        {
            this.Type= type;
        }
    }
}
