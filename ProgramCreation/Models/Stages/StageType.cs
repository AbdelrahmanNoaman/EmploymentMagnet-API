using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    //describes all the possible types of the stages that we may have in our workflow of the project
    public class StageType
    {
        private string? _id;
        private string _name;
        private string _description;

        public string Name { get { return _name; } set { this._name = value; } }

        public string Description { get { return _description; } set { this._description = value; } }
        public string? id { get { return _id; } set { this._id = value; } }

    }
}
