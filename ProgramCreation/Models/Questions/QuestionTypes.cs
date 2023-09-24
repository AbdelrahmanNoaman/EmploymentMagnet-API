using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    //This class contains the available types that any question can have which are multiple choice,short answer , paragraph , etc...
    public class QuestionTypes
    {
        private string _name;
        private string? _id;

        public string Name { get { return _name; } set { this._name = value; } }
        public string? id { get { return _id; } set { this._id = value; } }

    }
}
