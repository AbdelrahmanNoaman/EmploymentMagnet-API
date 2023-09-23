using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models.Stages
{
    public class StageType
    {
        private string _id;
        private string _name;
        private string _description;

        public string Name { get { return _name; } set { this._name = value; } }

        public string Description { get { return _description; } set { this._description = value; } }
        public string id { get; set; }
        public StageType(string name,string description,string id) {
            this.Name = name;
            this.Description = description;
            this.id = id;
        }
    }
}
