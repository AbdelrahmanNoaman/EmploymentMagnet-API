using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    //Stage is the base class that all the types of stages depend on
    //they all share the same things except the Video interview as it may contains a question inside of it and details about the interview so it inherits from this class
    public class Stage
    {
        private string _id;
        private string _name;
        private string _type;
        private bool _isShown;

        public string Id { get { return this._id; } set { this._id=value;} }
        public string Name { get { return this._name; } set { this._name = value; } }
        public string Type { get { return this._type; } set { this._type = value; } }
        public bool IsShown { get { return this._isShown; } set { this._isShown = value; } }

        public Stage(string id,string name,string type, bool isShown)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.IsShown = isShown;   
        }

    }
}
